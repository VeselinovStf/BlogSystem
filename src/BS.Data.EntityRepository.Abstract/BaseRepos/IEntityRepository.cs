using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BS.Data.EntityRepository.Abstract
{
    public interface IEntityRepository<T> : IEntityIntGetId<T>, IEntityAddRepository<T>
    {       
      
        Task Update(T updateObj);
        
    }
}
