using System;
using System.Collections.Generic;

namespace BS.Services.ModelFactory.Abstract
{
    public interface IServiceListModelFactory<T,D>
    {
        IEnumerable<T> Create(D inputType);
    }
}
