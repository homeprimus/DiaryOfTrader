using System.ComponentModel;
using System.IO;

namespace DiaryOfTrader.EditDialogs
{
  public partial class GridEditDialog : OKCancelDialog
  {

    #region fields
    private List<object> _data;
    private List<object> _modify;
    #endregion field

    public GridEditDialog()
    {
      InitializeComponent();
    }
    public void DoLoad<T, L>(IRepository<T> repository, ILogger<L> logger) where T : Entity
    {
      _data = new List<object>(repository.GetAllAsync().Result.OrderBy(e => e.Order).ToList());
      _modify = new List<object>(_data);

      grid.DataSource = new BindingList<object>(_data);
    }

    public void DoUpdate<T, L>(IRepository<T> repository, ILogger<L> logger) where T : Entity
    {

      var data = new List<T>();
      _data.ForEach(e=>data.Add((T)e));
      var modify = new List<T>();
      _modify.ForEach(e=>modify.Add((T)e));

      var ins = data.Where(e => !modify.Contains(e) && e.Validate).ToList();
      var del = modify.Where(e => !data.Contains(e)).Select(e => e.ID).ToList();
      data.RemoveAll(e => del.Contains(e.ID));

      if (del.Count > 0)
      {
        repository.DeleteAsync(del);
      }
      if (ins.Count > 0)
      {
        repository.InsertAsync(ins);
      }

      if (data.Count > 0)
      {
        repository.UpdateAsync(data);
      }
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
        grid.gridView.RestoreLayoutFromXml(GridLayoutStore);
      }
    }

    protected override void OnClosed(EventArgs e)
    {
      base.OnClosed(e);
      grid.gridView.SaveLayoutToXml(GridLayoutStore);
    }
  }
}
