using BS.Services.TagService.ModelDTO;
using BS.WEB.ModelFactory.Abstract;
using BS.WEB.ViewModels.Tag;
using System;
using System.Collections.Generic;
using System.Text;

namespace BS.WEB.TagModelFactory
{
    public class TagDeleteModelFactory : IModelFactory<TagDeleteViewModel, TagDetailsDTO>
    {
        public TagDeleteViewModel Create(TagDetailsDTO inputType)
        {
            return new TagDeleteViewModel()
            {
                Id = inputType.Id,
                CreatedOn = inputType.CreatedOn,
                ModifiedOn = inputType.ModifiedOn,
                Name = inputType.Name
            };
        }
    }
}
