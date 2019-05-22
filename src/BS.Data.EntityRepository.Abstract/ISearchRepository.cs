using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BS.Data.EntityRepository.Abstract
{
    public interface ISearchRepository<T>
    {
        Task<IList<string>> Get(string keyWord);

        Task<IList<T>> GetModel(string keyWord);
    }
}
