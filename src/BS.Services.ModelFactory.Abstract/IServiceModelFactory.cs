using System;
using System.Collections.Generic;
using System.Text;

namespace BS.Services.ModelFactory.Abstract
{
    public interface IServiceModelFactory<T, D>
    {
        T Create(D inputType);
    }
}
