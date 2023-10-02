using DiaryOfTrader.Core.Entity;
using DiaryOfTrader.Core.Interfaces.Repository;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace DiaryOfTrader.WebBlazor.Core.Pages;

public partial class AllMarketReviewPage
{
  private List<MarketReview> MarketReviews { get; set; }

  [Inject] public IMarketReviewRepository MarketReviewRepository { get; set; }

  private int _row = 0;


  protected override async Task OnInitializedAsync()
  {
    MarketReviews = await MarketReviewRepository.GetAllAsync();
  }
}
