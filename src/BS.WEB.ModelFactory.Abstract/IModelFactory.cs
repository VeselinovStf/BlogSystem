using System;
using System.Collections.Generic;

namespace BS.WEB.ModelFactory.Abstract
{
    public interface IModelFactory<T, D>
    {
        T Create(D inputType);
    }
}
