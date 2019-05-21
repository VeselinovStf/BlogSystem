using BS.Data.Models;
using BS.Services.ModelFactory.Abstract;
using BS.Services.TagService.ModelDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BS.Services.TagService.ModelFactory
{
    public class TagModelFactory : IServiceModelFactory<TagDetailsDTO, Tag>
    {
        public TagDetailsDTO Create(Tag inputType)
        {
            return new TagDetailsDTO()
            {
                Id = inputType.Id,
                CreatedOn = inputType.CreatedOn,
                ModifiedOn = inputType.ModifiedOn,
                Name = inputType.Name
            };
        }
    }
}
