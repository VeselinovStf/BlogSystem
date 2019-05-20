using BS.Data.EntityRepository.Abstract;
using BS.Data.Models;
using BS.Services.BlogPostService.Abstract;
using BS.Services.BlogPostService.ModelDTO;
using BS.Services.ModelFactory.Abstract;
using BS.Services.ServiceValidator;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BS.Services.BlogPostService
{
    public class BlogPostService : IBlogPostService
    {
        private readonly IEntityRepository<BlogPost> blogPostRepo;
        private readonly IServiceListModelFactory<BlogPostDTO, IEnumerable<BlogPost>> blogSetModelFactory;
        private readonly IServiceModelFactory<BlogPostDTO, BlogPost> blogModelFactory;

        public BlogPostService(IEntityRepository<BlogPost> blogPostRepo,
            IServiceListModelFactory<BlogPostDTO, IEnumerable<BlogPost>> blogSetModelFactory,
            IServiceModelFactory<BlogPostDTO, BlogPost> blogModelFactory)
        {
            this.blogPostRepo = blogPostRepo;
            this.blogSetModelFactory = blogSetModelFactory;
            this.blogModelFactory = blogModelFactory;
        }

        public async Task Edit(int id, int blogId, string title, string content, string userName)
        {
            ServiceValidator.ServiceValidator.IsLessThanOne(id, "Id can't be less then 1.");
            ServiceValidator.ServiceValidator.IsLessThanOne(blogId, "Id can't be less then 1.");
            ServiceValidator.ServiceValidator.AreEqual(id, blogId, "Id and Blog Id are not the same.");
            ServiceValidator.ServiceValidator.IsStringValid(title, "Title can't be null or white space.");
            ServiceValidator.ServiceValidator.IsStringValid(content, "Content can't be null or white space.");
            ServiceValidator.ServiceValidator.IsStringValid(content, "Editor name can't be null or white space.");

            try
            {
                var blogPost = await this.blogPostRepo.Get(blogId);

                ServiceValidator.ServiceValidator.IsNull(blogPost, "Can't find Blog to edin.");

                blogPost.LastEditedBy = userName;
                blogPost.Title = title;
                blogPost.Content = content;

                await this.blogPostRepo.Update(blogPost);              
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new ArgumentException(ex.Message, ex.InnerException);
            }
        }

        public async Task<BlogPostDTO> Get(int? id)
        {
            ServiceValidator.ServiceValidator.IsNull(id, "Id can't be null.");

            var repoCall = await this.blogPostRepo.Get(id);

            ServiceValidator.ServiceValidator.IsNull(repoCall, "Can't find Blog Post with this id.");

            var serviceModel = this.blogModelFactory.Create(repoCall);

            return serviceModel;
        }

        public async Task<IEnumerable<BlogPostDTO>> GetAll()
        {
            var repoCall = await this.blogPostRepo.GetAll();

            var serviceModel = this.blogSetModelFactory.Create(repoCall);

            return serviceModel;
        }

       
    }
}
