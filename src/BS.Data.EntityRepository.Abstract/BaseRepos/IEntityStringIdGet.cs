using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BS.Data.EntityRepository.Abstract
{
   public interface IEntityStringIdGet<T>
    {
        Task<T> Get(string Id);
    }
}
