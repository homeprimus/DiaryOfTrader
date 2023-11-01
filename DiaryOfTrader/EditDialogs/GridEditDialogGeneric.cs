using System.ComponentModel;
using System.IO;

namespace DiaryOfTrader.EditDialogs
{
  public partial class GridEditDialogGeneric<T> : OKCancelDialog where T : Entity
  {

    #region fields
    private List<T> _data;
    private List<T> _modify;
    private IRepository<T> _repository;
    private ILogger<GridEditDialogGeneric<T>> _logger;
    #endregion field

    public GridEditDialogGeneric(IRepository<T> repository, ILogger<GridEditDialogGeneric<T>> logger)
    {
      InitializeComponent();
      grid.Dock = DockStyle.Fill;
      _repository = repository;
      _logger = logger;
      DoLoad();
    }
    protected IRepository<T> Repository  => _repository;
    protected ILogger<GridEditDialogGeneric<T>> Logger =>_logger;
    public void DoLoad()
    {
      _data = new List<T>(_repository.GetAllAsync().Result.OrderBy(e => e.Order).ToList());
      _modify = new List<T>(_data);

      grid.DataSource = new BindingList<T>(_data);
    }

    public void DoUpdate() 
    {

      var ins = _data.Where(e => !_modify.Contains(e) && e.Validate).ToList();
      var del = _modify.Where(e => !_data.Contains(e)).Select(e => e.ID).ToList();
      _data.RemoveAll(e => del.Contains(e.ID));

      if (del.Count > 0)
      {
        _repository.DeleteAsync(del);
      }
      if (ins.Count > 0)
      {
        _repository.InsertAsync(ins);
      }

      if (_data.Count > 0)
      {
        _repository.UpdateAsync(_data);
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
