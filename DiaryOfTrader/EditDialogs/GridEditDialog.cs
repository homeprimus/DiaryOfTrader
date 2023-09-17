using System.IO;
using DiaryOfTrader.Core.Interfaces.Repository;

namespace DiaryOfTrader.EditDialogs
{
  public partial class GridEditDialog : OKCancelDialog
  {

    public GridEditDialog()
    {
      InitializeComponent();
    }


    //public IRepository<T> Repository<T>()
    //{
    //}

    protected string GridLayoutStore
    {
      get { return Path.Combine(SettingFolder, GetType().Name + ".GridLayout.xml"); }
    }

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);
      //_data = new List<T>(_repository.GetAllAsync().Result.OrderBy(e => e.Order).ToList());
      //_modify = new List<T>(_data);

      //grid.DataSource = new BindingList<T>(_modify);

      if (File.Exists(GridLayoutStore))
      {
        grid.gridView.RestoreLayoutFromXml(GridLayoutStore);
      }
    }

    protected override void OnOkClick()
    {
      base.OnOkClick();
      //var ins = _data.Where(e => !_modify.Contains(e) && e.Validate).ToList();
      //var del = _modify.Where(e => !_data.Contains(e)).Select(e => e.ID).ToList();
      //_data.RemoveAll(e=> del.Contains(e.ID));

      //if (del.Count > 0)
      //{
      //  _repository.DeleteAsync(del);
      //}
      //if (ins.Count > 0)
      //{
      //  _repository.InsertAsync(ins);
      //}

      //if (_data.Count > 0)
      //{
      //  _repository.UpdateAsync(_data);
      //}
    }
    protected override void OnClosed(EventArgs e)
    {
      base.OnClosed(e);
      grid.gridView.SaveLayoutToXml(GridLayoutStore);
    }
  }
}
