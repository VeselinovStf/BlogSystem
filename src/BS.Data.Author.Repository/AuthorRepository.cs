using BS.Data.EFContext;
using BS.Data.EntityRepository.Abstract;
using BS.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BS.Data.Author.Repository
{
    public class AuthorRepository : IEntityStringIdGet<Models.Author>
    {
        public AuthorRepository(BlogSystemEFDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public BlogSystemEFDbContext DbContext { get; }

        public async Task<Models.Author> Get(string Id)
        {
            return await this.DbContext.Authors
                .FirstOrDefaultAsync(a => a.AppUserId == Id);
        }
    }
}
