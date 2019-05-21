using BS.Data.Models;
using BS.Services.BlogPostService.ModelDTO;
using BS.Services.ModelFactory.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BS.Services.BlogPostService.ModelFactory
{
   public class BlogPostModelFactory : IServiceModelFactory<BlogPostDTO, BlogPost>
    {
        public BlogPostDTO Create(BlogPost inputType)
        {
            var model = new BlogPostDTO()
            {

                Id = inputType.Id,
                Author = inputType.Author.AppUser.UserName,
                BlogPostTags = inputType.BlogPostTag.Where(t => !t.Tag.IsDeleted).Select(t => new TagDTO()
                {
                    Name = t.Tag.Name
                }).ToList(),
                Content = inputType.Content,
                CreatedBy = inputType.CreatedBy,
                CreatedOn = inputType.CreatedOn,
                LastEditedBy = inputType.PostEditors.OrderBy(p => p.CreatedOn).First().EditorName,
                ModifiedOn = inputType.ModifiedOn,
                Title = inputType.Title


            };

            return model;
        }
    }
}
