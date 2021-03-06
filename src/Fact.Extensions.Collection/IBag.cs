﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fact.Extensions.Collection
{
    public interface IBag : IGetter, ISetter { }

    public interface IBagAsync : IGetterAsync, ISetterAsync { }

    public interface IBag<TKey, TValue> : IGetter<TKey, TValue>, ISetter<TKey, TValue> { }

    public interface IBagAsync<TKey, TValue> : IGetter<TKey, TValue>, ISetter<TKey, TValue> { }
}
