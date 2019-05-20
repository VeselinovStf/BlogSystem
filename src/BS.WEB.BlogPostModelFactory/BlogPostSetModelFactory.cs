using BS.Services.BlogPostService.ModelDTO;
using BS.WEB.ModelFactory.Abstract;
using BS.WEB.ViewModels.BlogPost;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BS.WEB.BlogPostModelFactory
{
    public class BlogPostSetModelFactory : IModelFactory<BlogPostSetViewModel, IEnumerable<BlogPostDTO>>
    {
        public BlogPostSetViewModel Create(IEnumerable<BlogPostDTO> inputType)
        {
            var model = new BlogPostSetViewModel()
            {
                Posts = inputType.Select(m => new BlogPostViewModel()
                {
                    Id = m.Id,
                    Author = m.Author,
                    BlogPostTags = m.BlogPostTags.Select(t => new TagViewModel()
                    {
                        Name = t.Name
                    }).ToList(),
                    Content = m.Content,
                    CreatedBy = m.CreatedBy,
                    CreatedOn = m.CreatedOn,
                    LastEditedBy = m.LastEditedBy,
                    ModifiedOn = m.ModifiedOn,
                    Title = m.Title

                })
            };

            return model;
        }
    }
}
