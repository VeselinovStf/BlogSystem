using BS.Data.EFContext;
using BS.Data.EntityRepository.Abstract;
using BS.Data.Models;
using System;
using System.Threading.Tasks;

namespace BS.Data.BlogPostTag.Repository
{
    public class BlogPostTagRepository : IEntityAddRepository<Models.BlogPostTag>
    {
        public BlogPostTagRepository(BlogSystemEFDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public BlogSystemEFDbContext DbContext { get; }
        public async Task Add(Models.BlogPostTag model)
        {
            await this.DbContext.BlogPostTags.AddAsync(model);

            await this.DbContext.SaveChangesAsync();
        }
    }
}
