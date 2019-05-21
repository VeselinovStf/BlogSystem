using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BS.Data.EntityRepository.Abstract
{
   public interface IEntityAddReturnRepository<T>
    {
        Task<T> Add(T addObject);
    }
}
