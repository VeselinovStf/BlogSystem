using BS.Data.EntityRepository.Abstract;
using BS.Data.Models;
using BS.Services.BlogPostService.Abstract;
using BS.Services.BlogPostService.ModelDTO;
using BS.Services.ModelFactory.Abstract;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BS.Services.BlogPostService
{
    public class BlogPostService : IBlogPostService
    {
        private readonly IEntityRepository<BlogPost> blogPostRepo;
        private readonly IServiceListModelFactory<BlogPostDTO, IEnumerable<BlogPost>> modelFactory;

        public BlogPostService(IEntityRepository<BlogPost> blogPostRepo,
            IServiceListModelFactory<BlogPostDTO, IEnumerable<BlogPost>> modelFactory)
        {
            this.blogPostRepo = blogPostRepo;
            this.modelFactory = modelFactory;
        }

        public async Task<IEnumerable<BlogPostDTO>> GetAll()
        {
            var repoCall = await this.blogPostRepo.GetAll();

            var serviceModel = this.modelFactory.Create(repoCall);

            return serviceModel;
        }
    }
}
