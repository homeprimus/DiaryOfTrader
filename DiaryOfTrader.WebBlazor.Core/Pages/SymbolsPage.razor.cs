﻿using DiaryOfTrader.Core.Entity;
using DiaryOfTrader.Core.Interfaces.Repository;
using Microsoft.AspNetCore.Components;

namespace DiaryOfTrader.WebBlazor.Core.Pages;

public partial class SymbolsPage
{
  public List<Symbol?> Symbols { get; set; }
  
  [Inject]
  public ISymbolRepository HttpRepo { get; set; }
  
  
  protected override async Task OnInitializedAsync()
  {
    Symbols = await HttpRepo.GetAllAsync();
  }

  private async Task DeleteSymbol(long id)
  { 
    await HttpRepo.DeleteAsync(id);
    Symbols.Remove(Symbols.FirstOrDefault(x => x.ID == id));
  }
}
