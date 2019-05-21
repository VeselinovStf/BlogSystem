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
    public class TagRepository : IEntityRepository<Tag>
    {
        public TagRepository(BlogSystemEFDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public BlogSystemEFDbContext DbContext { get; }
        public Task Add(Tag model)
        {
            throw new NotImplementedException("ADD TAG IS NOT IMPLEMENTED");
        }

        public async Task<Tag> Get(int? id)
        {
            return await this.DbContext.Tags
                .FirstOrDefaultAsync(t => t.Id == id && !t.IsDeleted);
        }

        public Task<IEnumerable<Tag>> GetAll()
        {
            throw new NotImplementedException("GET ALL TAGS IS NOT IMPLEMENTED");
        }

        public async Task Update(Tag updateObj)
        {
            this.DbContext.Tags.Update(updateObj);

            await this.DbContext.SaveChangesAsync();
        }
    }
}
