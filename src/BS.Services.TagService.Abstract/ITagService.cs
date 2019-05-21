using BS.Services.TagService.ModelDTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BS.Services.TagService.Abstract
{
    public interface ITagService
    {
        Task<IEnumerable<TagDetailsDTO>> GetAll(int id);

        Task<TagDetailsDTO> Get(int? id);
    }
}
