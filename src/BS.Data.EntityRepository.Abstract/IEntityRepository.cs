using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BS.Data.EntityRepository.Abstract
{
    public interface IEntityRepository<T>
    {       
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int? id);
        Task Update(T updateObj);
    }
}
