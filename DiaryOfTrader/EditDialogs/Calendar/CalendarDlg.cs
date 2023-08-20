
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using DevExpress.XtraEditors;
using DiaryOfTrader.Core;
using DiaryOfTrader.Core.Data;
using DiaryOfTrader.Core.Entity;
using DiaryOfTrader.Core.Entity.Economic;
using static DevExpress.Xpo.Helpers.AssociatedCollectionCriteriaHelper;

namespace DiaryOfTrader.EditDialogs.Calendar
{
  public partial class CalendarDlg : OKCancelDialog
  {
    private EconomicPeriod period = EconomicPeriod.today;
    private Importance importance = Importance.High;
    private CancellationTokenSource cancelTokenSource = new();

    private Task? updateTask;
    //private readonly DiaryOfTraderCtx contexDb = new();

    private Task? updateThisWeekAsync;
    public CalendarDlg()
    {
      InitializeComponent();

      gridView.Columns["Date"].Group();
    }

    private void CbEconomicImportance_SelectedIndexChanged(object? sender, EventArgs e)
    {
      var value= (Importance)((ComboBoxEdit)sender!).SelectedIndex;
      if (importance != value)
      {
        importance = value;
        Update(false);
      }
    }

    private void rgEconomicPeriod_EditValueChanged(object sender, EventArgs e)
    {
       var value  = (EconomicPeriod)((RadioGroup)sender!).SelectedIndex;
       if (period != value)
       {
         period = value;
         Update(false);
       }
    }

    [DefaultValue(null)]
    public DiaryOfTraderCtx? Contex { get; set; }

    private void Update(bool refresh = false)
    {
      bbiRefresh.Enabled = false;
      cancelTokenSource.Cancel();
      if (updateTask != null)
      {
        try
        {
          Task.WaitAll(updateTask);
        }
        catch (Exception e)
        {
          Debug.WriteLine(e);
        }
      }
      cancelTokenSource.Dispose();
      cancelTokenSource = new();

      ScreenCursor.WaitCursor();
      if (!splashScreenManager.IsSplashFormVisible)
      {
        splashScreenManager.ShowWaitForm();
      }

      updateTask = Task.Run(() => DoUpdate(refresh));
    }

    private void DoRehresh(List<EconomicSchedule> economic)
    {
      var data = economic
        .Join(
          EconomicSchedule.Importances,
          e => e.Importance,
          i => (int)i.Key,
          (e, i)
            => new EventCalendar()
            {
              Date = e.Time,
              Time = e.Time.ToString("HH:mm"),
              Currency = e.Currency,
              Importance = i.Value,
              Description = e.Description,
              Factual = e.Factual,
              Prognosis = e.Prognosis,
              Previous = e.Previous,
              Node = e.Event?.Description!
            }
        ).ToList();

      if (InvokeRequired)
      {
        Invoke(
          new MethodInvoker
          (
            delegate
            {
              clImportance.VisibleIndex = 2;
              clImportance.Visible = importance == Importance.None;

              grid.DataSource = new BindingList<EventCalendar>(data);
              if (splashScreenManager.IsSplashFormVisible)
              {
                splashScreenManager.CloseWaitForm();
              }
              ScreenCursor.Unset();
              bbiRefresh.Enabled = true;
            }
          )
        );
      }
    }

    private void DoUpdate(bool refresh = false)
    {
      var parser = new EconomicParser(Contex!, cancelTokenSource.Token);
      var result = parser.ParseAsync(refresh, period, importance).Result;
      DoRehresh(result);
      Task.Run(() => parser.EventsAsync(result, () => DoRehresh(result), false));
    }

    private void CalendarDlg_Load(object sender, EventArgs e)
    {
      beiEconomicPeriod.EditValue = (int)EconomicPeriod.today;
      beiEconomicImportance.EditValue = cbEconomicImportance.Items[^1];

      rgEconomicPeriod.EditValueChanged += rgEconomicPeriod_EditValueChanged;
      cbEconomicImportance.SelectedIndexChanged += CbEconomicImportance_SelectedIndexChanged;

      Update(false);
    }

    protected string GridLayoutStore
    {
      get { return Path.Combine(SettingFolder, GetType().Name + ".GridLayout.xml"); }
    }

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);
      if (File.Exists(GridLayoutStore))
      {
        gridView.RestoreLayoutFromXml(GridLayoutStore);
      }
    }

    protected override void OnClosed(EventArgs e)
    {
      base.OnClosed(e);
      gridView.SaveLayoutToXml(GridLayoutStore);
    }

    private async void bbiRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
      Update(true);
    }

    private void FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
    {
      if (e.FocusedRowHandle > -1)
      {
        var bindingCalendar = (EventCalendar)gridView.GetRow(e.FocusedRowHandle);
        html.HtmlTemplate.Template = bindingCalendar.Node;
      }
      else
      {
        html.HtmlTemplate.Template = string.Empty;
      }
    }

  }

}
