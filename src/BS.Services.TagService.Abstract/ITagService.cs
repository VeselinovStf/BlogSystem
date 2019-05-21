using BS.Services.TagService.ModelDTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BS.Services.TagService.Abstract
{
    public interface ITagService
    {
        Task<TagSetDTO> GetAll(int id);

        Task<TagDetailsDTO> Get(int? id);

        Task Edit(int id, int tagId, string name, string userName);

        Task Create(int id, string name, int blogId);
        Task Remove(int id);
    }
}
