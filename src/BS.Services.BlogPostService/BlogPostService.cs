using BS.Data.EntityRepository.Abstract;
using BS.Data.Models;
using BS.Services.BlogPostService.Abstract;
using BS.Services.BlogPostService.ModelDTO;
using BS.Services.ModelFactory.Abstract;
using BS.Services.ServiceValidator;
using DateTimeWrapper.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BS.Services.BlogPostService
{
    public class BlogPostService : IBlogPostService
    {
        private readonly IBlogPostRepository blogPostRepo;
        private readonly IEntityStringIdGet<Author> authorRepo;
        private readonly IServiceListModelFactory<BlogPostDTO, IEnumerable<BlogPost>> blogSetModelFactory;
        private readonly IServiceModelFactory<BlogPostDTO, BlogPost> blogModelFactory;
        private readonly IDateTimeWrapper dateTimeProvider;

        public BlogPostService(IBlogPostRepository blogPostRepo,
             IEntityStringIdGet<Author> authorRepo,
            IServiceListModelFactory<BlogPostDTO, IEnumerable<BlogPost>> blogSetModelFactory,
            IServiceModelFactory<BlogPostDTO, BlogPost> blogModelFactory,
            IDateTimeWrapper dateTimeProvider)
        {
            this.blogPostRepo = blogPostRepo;
            this.authorRepo = authorRepo;
            this.blogSetModelFactory = blogSetModelFactory;
            this.blogModelFactory = blogModelFactory;
            this.dateTimeProvider = dateTimeProvider;
        }

        public async Task Create(string title, string content, string userName, string authorId)
        {
            ServiceValidator.ServiceValidator.IsStringValid(title, "Title can't be null or white space.");
            ServiceValidator.ServiceValidator.IsStringValid(content, "Content can't be null or white space.");
            ServiceValidator.ServiceValidator.IsStringValid(userName, "Editor name can't be null or white space.");
            ServiceValidator.ServiceValidator.IsStringValid(authorId, "Editor name can't be null or white space.");


            var author = await this.authorRepo.Get(authorId);

            ServiceValidator.ServiceValidator.IsNull(author, "Object get fails.");

            var editor = new BlogPostEditor()
            {
                CreatedOn = this.dateTimeProvider.Now(),
                EditorName = userName
            };

            var newBlogPost = new BlogPost()
            {
                AuthorId = author.Id,
                CreatedBy = userName,
                Content = content,
                Title = title,
                CreatedOn = this.dateTimeProvider.Now(),               
                ModifiedOn = this.dateTimeProvider.Now(),
                 PostEditors = new List<BlogPostEditor>()
                 {
                      new BlogPostEditor()
                      {
                           CreatedOn = this.dateTimeProvider.Now(),
                           EditorName = userName
                      }
                 }
            };      

            ServiceValidator.ServiceValidator.IsNull(newBlogPost, "Object creation fails.");

            try
            {
                await this.blogPostRepo.Add(newBlogPost);

            }
            catch(DbUpdateException ex)
            {
                throw new DbUpdateException($"Db Update Exception : {ex.Message} : {ex.InnerException.Message}", ex.InnerException);
            }
            catch (Exception ex)
            {

                throw new InvalidOperationException("Can't Create blog post.");
            }

        }

        public async Task Edit(int id, int blogId, string title, string content, string userName)
        {
            ServiceValidator.ServiceValidator.IsLessThanOne(id, "Id can't be less then 1.");
            ServiceValidator.ServiceValidator.IsLessThanOne(blogId, "Id can't be less then 1.");
            ServiceValidator.ServiceValidator.AreEqual(id, blogId, "Id and Blog Id are not the same.");
            ServiceValidator.ServiceValidator.IsStringValid(title, "Title can't be null or white space.");
            ServiceValidator.ServiceValidator.IsStringValid(content, "Content can't be null or white space.");
            ServiceValidator.ServiceValidator.IsStringValid(userName, "Editor name can't be null or white space.");

            try
            {
                var blogPost = await this.blogPostRepo.Get(blogId);

                ServiceValidator.ServiceValidator.IsNull(blogPost, "Can't find Blog to edin.");

                var postEditor =   new BlogPostEditor()
                {
                    BlogPostId = blogPost.Id,
                    CreatedOn = this.dateTimeProvider.Now(),
                    EditorName = userName,
                };

                blogPost.PostEditors.Add(postEditor);
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

        public async Task Remove(int id)
        {
            ServiceValidator.ServiceValidator.IsNull(id, "Id can't be null.");

            var repoCall = await this.blogPostRepo.Get(id);

            repoCall.IsDeleted = true;

            await this.blogPostRepo.Update(repoCall);
        }
    }
}
