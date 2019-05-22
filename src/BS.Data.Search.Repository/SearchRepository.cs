using BS.Data.EFContext;
using BS.Data.EntityRepository.Abstract;
using BS.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BS.Data.Search.Repository
{
    public class SearchRepository : ISearchRepository<BlogPost>
    {
        private readonly BlogSystemEFDbContext dbContext;

        public SearchRepository(BlogSystemEFDbContext DbContext)
        {
            dbContext = DbContext;
        }
        public async Task<IList<string>> Get(string keyWord)
        {
            var result = await this.dbContext.BlogPosts
            .Where(post => post.BlogPostTag
              .Any(tag => tag.Tag.Name.Contains(keyWord) && !tag.Tag.IsDeleted) || post.Title.Contains(keyWord))
            .Select(t => t.Title).Distinct().ToListAsync();

            return result;
        }

        public async Task<IList<BlogPost>> GetModel(string keyWord)
        {
            var result = await this.dbContext.BlogPosts
           .Where(post => post.BlogPostTag
             .Any(tag => tag.Tag.Name.Contains(keyWord) && !tag.Tag.IsDeleted) || post.Title.Contains(keyWord))
             .Include(p => p.Author.AppUser)
                    .Include(p => p.BlogPostTag)
                        .ThenInclude(c => c.Tag)
                    .Include(p => p.PostEditors)
                    .Where(p => !p.IsDeleted)
                    .OrderBy(p => p.CreatedOn)
           .Distinct().ToListAsync();

            return result;
        }
    }
}
