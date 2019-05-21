using BS.Services.BlogPostService.ModelDTO;
using BS.WEB.ModelFactory.Abstract;
using BS.WEB.ViewModels.BlogPost;
using BS.WEB.ViewModels.Tag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BS.WEB.BlogPostModelFactory
{
    public class DeleteBlogPostModelFactory : IModelFactory<BlogPostDeleteViewModel, BlogPostDTO>
    {
        public BlogPostDeleteViewModel Create(BlogPostDTO inputType)
        {
            var model = new BlogPostDeleteViewModel() { 

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
