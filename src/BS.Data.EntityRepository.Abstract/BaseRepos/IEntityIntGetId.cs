using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BS.Data.EntityRepository.Abstract
{
   public interface IEntityIntGetId<T>
    {
        Task<T> Get(int? id);
    }
}
