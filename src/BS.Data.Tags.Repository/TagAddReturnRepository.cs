using BS.Data.EFContext;
using BS.Data.EntityRepository.Abstract;
using BS.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BS.Data.Tags.Repository
{
    public class TagAddReturnRepository : IEntityAddReturnRepository<Tag>
    {
        public TagAddReturnRepository(BlogSystemEFDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public BlogSystemEFDbContext DbContext { get; }
        public async Task<Tag> Add(Tag addObject)
        {
            var addedTag = await this.DbContext.Tags.AddAsync(addObject);

            await this.DbContext.SaveChangesAsync();

            return await this.DbContext.Tags.FirstOrDefaultAsync(t => t.Id == addedTag.Entity.Id);            
        }
    }
}
