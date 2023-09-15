using System.ComponentModel;

namespace DiaryOfTrader.EditDialogs
{
  public partial class PictureEditDlg : OKCancelDialog
  {
    public PictureEditDlg()
    {
      InitializeComponent();
    }

    [DefaultValue(null)]
    public Image Image
    {
      get { return pictureEdit.Image; }

      set
      {
        pictureEdit.Image = value;
      }
    }
  }
}
