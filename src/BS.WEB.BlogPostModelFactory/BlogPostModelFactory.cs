using BS.Data.Models;
using BS.Services.BlogPostService.ModelDTO;
using BS.WEB.ModelFactory.Abstract;
using BS.WEB.ViewModels.BlogPost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BS.WEB.BlogPostModelFactory
{
    public class BlogPostModelFactory : IModelFactory<BlogPostDetailsViewModel, BlogPostDTO>
    {      
        public BlogPostDetailsViewModel Create(BlogPostDTO inputType)
        {
            var model = new BlogPostDetailsViewModel()
            {
               
                    Id = inputType.Id,
                    Author = inputType.Author,
                    BlogPostTags = inputType.BlogPostTags.Select(t => new TagViewModel()
                    {
                        Name = t.Name
                    }).ToList(),
                    Content = inputType.Content,
                    CreatedBy = inputType.CreatedBy,
                    CreatedOn = inputType.CreatedOn,
                    LastEditedBy = inputType.LastEditedBy,
                    ModifiedOn = inputType.ModifiedOn,
                    Title = inputType.Title

                
            };

            return model;
        }
    }
}
