using Exchange.Abstracts;

namespace DiaryOfTrader.EditDialogs
{
  public partial class MarketReviewDlg : MarketReviewDlgAbstract
  {
    public MarketReviewDlg()
    {
      InitializeComponent();
    }

    protected override void OnInitializeInstance()
    {
      base.OnInitializeInstance();
      marketReviewCtrl.Element = Element;
    }

    protected override void InstancePropertyChanged(string name)
    {
      base.InstancePropertyChanged(name);
    }
  }
}
