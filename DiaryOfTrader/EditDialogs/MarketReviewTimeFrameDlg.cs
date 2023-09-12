
namespace DiaryOfTrader.EditDialogs
{
  public partial class MarketReviewTimeFrameDlg : MarketReviewTimeFrameDlgAbstract
  {
    public MarketReviewTimeFrameDlg()
    {
      InitializeComponent();
    }

    protected override void OnInitializeInstance()
    {
      base.OnInitializeInstance();
      marketReviewTimeFrameCtrl.Element = Element;
    }

    protected override void InstancePropertyChanged(string name)
    {
      base.InstancePropertyChanged(name);
    }
  }

}

