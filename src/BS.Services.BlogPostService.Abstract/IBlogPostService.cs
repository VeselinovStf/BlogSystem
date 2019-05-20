using BS.Services.BlogPostService.ModelDTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BS.Services.BlogPostService.Abstract
{
    public interface IBlogPostService
    {
        Task<IEnumerable<BlogPostDTO>> GetAll();

        Task<BlogPostDTO> Get(int? id);
        Task Edit(int id, int blogId, string title, string content, string userName);
    }
}
