using BS.Data.EFContext;
using BS.Data.EntityRepository.Abstract;
using BS.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BS.Data.Tags.Repository
{
    public class TagIdGetRepository : IEntityIntGetId<IEnumerable<Tag>>
    {

         public TagIdGetRepository(BlogSystemEFDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public BlogSystemEFDbContext DbContext { get; }

        public async Task<IEnumerable<Tag>> Get(int? id)
        {
            return await this.DbContext.BlogPostTags
                .Where(t => t.BlogPostId == id)
                .Select(t => t.Tag)
                .Where(t => !t.IsDeleted)
                .ToListAsync();
        }

     
    }
}