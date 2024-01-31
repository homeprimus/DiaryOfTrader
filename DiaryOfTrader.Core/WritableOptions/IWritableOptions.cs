﻿using Microsoft.Extensions.Options;

namespace DiaryOfTrader.Core.WritableOptions
{
  public interface IWritableOptions<out T> : IOptions<T> where T : class, new()
  {
    void Update(Action<T> applyChanges);
  }
}
