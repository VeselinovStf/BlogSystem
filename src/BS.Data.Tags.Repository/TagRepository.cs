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
    public class TagRepository : IEntityIntGetId<IEnumerable<Tag>>//, IEntityRepository<Tag>,
    {

         public TagRepository(BlogSystemEFDbContext dbContext)
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

        //public async Task Add(Tag model)
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<Tag> Get(int? id)
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<IEnumerable<Tag>> GetAll()
        //{
           
        //}

        //public Task Update(Tag updateObj)
        //{
        //    throw new NotImplementedException();
        //}
    }
}