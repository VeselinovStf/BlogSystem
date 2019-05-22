using BS.Data.EntityRepository.Abstract;
using BS.Data.Models;
using BS.Service.BlogSearchService.DTO;
using BS.Services.BlogSearchService.Abstract;
using BS.Services.ModelFactory.Abstract;
using BS.Services.ServiceValidator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BS.Services.BlogSearchService
{
    public class BlogSearchService : IBlogSearchService
    {
        private readonly ISearchRepository<BlogPost> searchRepo;
        private readonly IServiceListModelFactory<SearchBlogPostResultDTO, IEnumerable<BlogPost>> modelFactory;

        public BlogSearchService(
            ISearchRepository<BlogPost> searchRepo,
            IServiceListModelFactory<SearchBlogPostResultDTO, IEnumerable<BlogPost>> modelFactory)
        {
            this.searchRepo = searchRepo;
            this.modelFactory = modelFactory;
        }
        public async Task<IList<SearchBlogPostResultDTO>> GetFindResult(string searchKey)
        {
            ServiceValidator.ServiceValidator.IsStringValid(searchKey, "Search word can't be null or white space.");

            try
            {
                var repoCall = await this.searchRepo.GetModel(searchKey);

                ServiceValidator.ServiceValidator.IsNull(repoCall, "Search return null objects.");

                var serviceModel = this.modelFactory.Create(repoCall);

                return serviceModel.ToList();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<IList<string>> GetSearchResults(string searchKey)
        {
            ServiceValidator.ServiceValidator.IsStringValid(searchKey, "Search word can't be null or white space.");


            try
            {
                var repoCall = await this.searchRepo.Get(searchKey);

                ServiceValidator.ServiceValidator.IsNull(repoCall, "Search return null objects.");

                return repoCall;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
