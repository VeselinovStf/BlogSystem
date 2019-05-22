using BS.Service.BlogSearchService.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BS.Services.BlogSearchService.Abstract
{
    public interface IBlogSearchService
    {
        Task<IList<string>> GetSearchResults(string searchKey);

        Task<IList<SearchBlogPostResultDTO>> GetFindResult(string searchKey);
    }
}
