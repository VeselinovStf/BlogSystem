﻿using BS.Data.EFContext;
using BS.Data.EntityRepository.Abstract;
using BS.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BS.Data.BlogPostsRepository
{
    public class BlogPostRepository : IEntityRepository<BlogPost>
    {
        public BlogPostRepository(BlogSystemEFDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public BlogSystemEFDbContext DbContext { get; }

      

        public async Task<IEnumerable<BlogPost>> GetAll()
        {
            return await this.DbContext
                .BlogPosts
                    .Include(p => p.Author.AppUser)
                    .Include(p => p.BlogPostTag)
                    .ThenInclude(c => c.Tag)
                    .ToListAsync();
        }

        public async Task<BlogPost> Get(int? id)
        {
            return await this.DbContext.BlogPosts
               .Include(p => p.Author.AppUser)
                    .Include(p => p.BlogPostTag)
                    .ThenInclude(c => c.Tag)
               .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task Update(BlogPost updateObj)
        {
            this.DbContext.BlogPosts.Update(updateObj);

            await this.DbContext.SaveChangesAsync();
        }
    }
}
