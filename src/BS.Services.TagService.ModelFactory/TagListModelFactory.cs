using BS.Data.Models;
using BS.Services.ModelFactory.Abstract;
using BS.Services.TagService.ModelDTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BS.Services.TagService.ModelFactory
{
    public class TagListModelFactory :  IServiceModelFactory<IEnumerable<TagDetailsDTO>, IEnumerable<Tag>>
    {
        public IEnumerable<TagDetailsDTO> Create(IEnumerable<Tag> inputType)
        {
            var model = inputType.Select(t => new TagDetailsDTO()
            {
                Id = t.Id,
                CreatedOn = t.CreatedOn,
                ModifiedOn = t.ModifiedOn,
                Name = t.Name
            });

            return model;
        }
    }
}
