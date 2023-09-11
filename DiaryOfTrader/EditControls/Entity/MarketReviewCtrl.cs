using System.Windows.Controls;
using DiaryOfTrader.Core;
using Exchange.Abstracts;

namespace DiaryOfTrader.EditControls.Entity
{
  public partial class MarketReviewCtrl : MarketReviewCtrlAbstract
  {
    public MarketReviewCtrl()
    {
      InitializeComponent();
      gnReview.View = gvTimeFrame;
      gnReview.Add += delegate (object entity)
      {
        var frame = entity == null ? Element.AddFrame() : (MarketReviewTimeFrame)entity;
        frame.Market = Element;
        Element.Frames.Add(frame);

        //gcTimeFrame.DataSource = Element.Frames;
        gvTimeFrame.RefreshData();
      };

      gnReview.Delete += delegate (object entity)
      {
        if (entity != null)
        {
          var frame = (MarketReviewTimeFrame)entity;
          Element.Frames.Remove(frame);

          //gcTimeFrame.DataSource = Element.Frames;
          gvTimeFrame.RefreshData();
        }
      };

    }
    protected override void OnInitializeInstance()
    {
      base.OnInitializeInstance();
      BindingUtils.Bind(dateEdit, "DateTime", Element, "DateTime");

      BindingUtils.BindCombo(lcbExchange, Element, "Exchange", MarketReview.ExchangeList);
      BindingUtils.BindCombo(lcbSymbol, Element, "Symbol", MarketReview.SymbolList);

      BindingUtils.Bind(txtName, BindingUtils.Text, Element, "Name");
      BindingUtils.Bind(mmDescription, BindingUtils.Text, Element, "Description");

      gcTimeFrame.DataSource = Element.Frames;

      luFrame.DataSource = MarketReview.FrameList;
      luTrend.DataSource = MarketReview.TrendList;
    }
  }
}
