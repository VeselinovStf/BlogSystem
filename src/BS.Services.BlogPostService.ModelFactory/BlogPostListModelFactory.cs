using BS.Data.Models;
using BS.Services.BlogPostService.ModelDTO;
using BS.Services.ModelFactory.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BS.Services.BlogPostService.ModelFactory
{
    public class BlogPostListModelFactory : IServiceListModelFactory<BlogPostDTO, IEnumerable<BlogPost>>
    {  
        public IEnumerable<BlogPostDTO> Create(IEnumerable<BlogPost> inputType)
        {
            var model = inputType.Select(m => new BlogPostDTO()
            {
                Id = m.Id,
                Author = m.Author.AppUser.UserName,
                BlogPostTags = m.BlogPostTag.Select(t => new TagDTO()
                {
                    Name = t.Tag.Name
                }).ToList(),
                Content = m.Content,
                CreatedBy = m.CreatedBy,
                CreatedOn = m.CreatedOn,
                LastEditedBy = m.LastEditedBy,
                ModifiedOn = m.ModifiedOn,
                Title = m.Title

            });

            return model;
            
        }
    }
}
