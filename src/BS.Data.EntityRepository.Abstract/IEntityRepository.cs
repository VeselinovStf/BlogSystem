﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BS.Data.EntityRepository.Abstract
{
    public interface IEntityRepository<T> : IEntityIntGetId<T>
    {       
        Task<IEnumerable<T>> GetAll();
        Task Update(T updateObj);
        Task Add(T model);
    }
}
