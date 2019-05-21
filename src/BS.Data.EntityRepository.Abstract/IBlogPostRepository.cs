using BS.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BS.Data.EntityRepository.Abstract
{
    public interface IBlogPostRepository : IEntityRepository<BlogPost>, IEntityGetAllRepository<BlogPost>
    {
    }
}
