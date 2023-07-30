
using System.ComponentModel;
using DevExpress.XtraEditors;
using DiaryOfTrader.Core.Data;
using DiaryOfTrader.Core.Entity.Economic;

namespace DiaryOfTrader.EditDialogs.Calendar
{
  public partial class CalendarDlg : OKCancelDialog
  {
    private EconomicPeriod period = EconomicPeriod.today;
    private Importance importance = Importance.High;
    private readonly CancellationTokenSource cancelTokenSource = new();
    //private readonly DiaryOfTraderCtx contexDb = new();

    private Task? updateThisWeekAsync;
    public CalendarDlg()
    {
      InitializeComponent();

      gridView.Columns["Date"].Group();
    }

    private void CbEconomicImportance_SelectedIndexChanged(object? sender, EventArgs e)
    {
      importance = (Importance)((ComboBoxEdit)sender!).SelectedIndex;
      Update(false);
    }

    private void RgEconomicPeriod_SelectedIndexChanged(object? sender, EventArgs e)
    {
      period = (EconomicPeriod)((RadioGroup)sender!).SelectedIndex;
      Update(false);
    }

    [DefaultValue(null)]
    public DiaryOfTraderCtx? Contex { get; set; }


    private async Task Update(bool refresh = false)
    {
      var parser = new EconomicParser(Contex, cancelTokenSource.Token);
      var result = await parser.ParseAsync(refresh, period, importance);

      var data = result
        .Join(
          EconomicSchedule.Importances,
          e => e.Importance,
          i => (int)i.Key,
          (e, i)
            => new BindingCalendar()
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

      clImportance.VisibleIndex = 2;
      clImportance.Visible = importance == Importance.None;

      grid.DataSource = new BindingList<BindingCalendar>(data);
    }

    private void CalendarDlg_Load(object sender, EventArgs e)
    {
      beiEconomicPeriod.EditValue = (int)EconomicPeriod.today;
      beiEconomicImportance.EditValue = cbEconomicImportance.Items[^1];

      rgEconomicPeriod.SelectedIndexChanged += RgEconomicPeriod_SelectedIndexChanged;
      cbEconomicImportance.SelectedIndexChanged += CbEconomicImportance_SelectedIndexChanged;

      Update(false);
    }

    private void bbiRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
      Update(true);
    }
  }

  public class BindingCalendar
  {
    public DateTime Date { get; set; }
    public string Time { get; set; }
    public string Currency { get; set; }
    public string Importance { get; set; }
    public string Description { get; set; }
    public string Factual { get; set; }
    public string Prognosis { get; set; }
    public string Previous { get; set; }
    public string Node { get; set; }
  }

}
