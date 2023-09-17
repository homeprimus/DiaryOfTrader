using System.ComponentModel;
using DevExpress.XtraEditors.Controls;
using DiaryOfTrader.Properties;
using MessageBox = DiaryOfTrader.Core.MessageBox;

namespace DiaryOfTrader.Components
{
  public partial class PictureEdit : CoreControl
  {
    public PictureEdit()
    {
      InitializeComponent();
      RefreshAction();
    }

    private void RefreshAction()
    {
      var bEnabled = false;
      bbtAdd.Enabled = bEnabled;
      bbtEdit.Enabled = bEnabled;
      bbtRefresh.Enabled = bEnabled;

      bbtDelete.Enabled = true;

      bbiStrech.Enabled = Mode != PictureSizeMode.Stretch;
      bbiClip.Enabled = Mode != PictureSizeMode.Clip;
    }

    [DefaultValue(null)]
    public Image Image
    {
      get { return Picture.Image; }

      set
      {
        Picture.Image = value;
      }
    }

    private PictureSizeMode Mode
    {
      get
      {
        return Picture.Properties.SizeMode;
      }
      set
      {
        Picture.Properties.SizeMode = value;
      }
    }

    private void bbtAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
      RefreshAction();
    }

    private void bbtEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
      RefreshAction();
    }

    private void bbtDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
      if (MessageBox.ShowQuestionYesNo(Resources.DeleteImage, Resources.DeleteQuestion) == DialogResult.Yes)
      {
        Image = null;
        RefreshAction();
      }
    }

    private void bbtRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
      RefreshAction();
    }

    private void bbiStrech_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
      
      Mode = PictureSizeMode.Stretch;
      RefreshAction();
    }

    private void bbiClip_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
      Mode = PictureSizeMode.Clip;
      RefreshAction();
    }
  }
}
