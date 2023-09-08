using DiaryOfTrader.Core;
using Exchange.Abstracts;

namespace DiaryOfTrader.EditControls.Entity
{
  public partial class MarketReviewCtrl : MarketReviewCtrlAbstract
  {
    public MarketReviewCtrl()
    {
      InitializeComponent();

    }
    protected override void OnInitializeInstance()
    {
      base.OnInitializeInstance();
      BindingUtils.Bind(dateEdit, "DateTime", Element, "DateTime");

      BindingUtils.BindCombo(lcbExchange, Element, "Exchange", MarketReview.Exchanges);
      BindingUtils.BindCombo(lcbSymbol, Element, "Symbol", MarketReview.Symbols);

      BindingUtils.Bind(txtName, BindingUtils.Text, Element, "Name");
      BindingUtils.Bind(mmDescription, BindingUtils.Text, Element, "Description");

      gcTimeFrame.DataSource = Element.Frames;
    }
  }
}
