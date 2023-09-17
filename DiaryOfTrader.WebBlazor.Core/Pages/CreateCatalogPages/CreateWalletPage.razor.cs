
using DiaryOfTrader.Core.Entity;
using Microsoft.AspNetCore.Components.Forms;

namespace DiaryOfTrader.WebBlazor.Core.Pages.CreateCatalogPages;

public partial class CreateWalletPage
{
  private Wallet _wallet = new Wallet();
  private EditContext _editContext;
  private bool _formInvalid = true;
  
  private Task Create()
  {
    throw new NotImplementedException();
  }
}
