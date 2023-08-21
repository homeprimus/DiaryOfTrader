// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using DiaryOfTrader.Core.Entity;
using Microsoft.AspNetCore.Components;

namespace DiaryOfTrader.WebBlazor.Core.Components;

public partial class WalletTable
{
  [Parameter]
  public List<Wallet> Wallets { get; set; }
}
