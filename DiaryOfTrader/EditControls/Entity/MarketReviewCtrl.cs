using System.ComponentModel;
using DiaryOfTrader.Abstracts;
using DiaryOfTrader.Core;
using DiaryOfTrader.Core.Interfaces;
using DiaryOfTrader.EditDialogs;

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
        var frame = (MarketReviewTimeFrame)entity;
        Element.SetFrame(frame);
        var edit = new MarketReviewTimeFrameDlg();
        edit.Edit(frame, EditModeUI.AllowEdit);
        gvTimeFrame.RefreshData();
      };

      gnReview.Delete += delegate (object entity)
      {
        gvTimeFrame.RefreshData();
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

      gcTimeFrame.DataSource = new BindingList<MarketReviewTimeFrame>(Element.Frames); ;

      luFrame.DataSource = MarketReview.FrameList;
      luTrend.DataSource = MarketReview.TrendList;
    }

  }
}
