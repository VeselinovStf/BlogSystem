using BS.Services.BlogPostService.ModelDTO;
using BS.WEB.ModelFactory.Abstract;
using BS.WEB.ViewModels.BlogPost;
using System;
using System.Collections.Generic;
using System.Text;

namespace BS.WEB.BlogPostModelFactory
{
    public class EditBlogPostModelFactory : IModelFactory<BlogPostEditViewModel, BlogPostDTO>
    {
        public BlogPostEditViewModel Create(BlogPostDTO inputType)
        {
            return new BlogPostEditViewModel()
            {
                Id = inputType.Id,
                Content = inputType.Content,
                Title = inputType.Title
            };
        }
    }
}
