using BS.Services.TagService.ModelDTO;
using BS.WEB.ModelFactory.Abstract;
using BS.WEB.ViewModels.Tag;
using System;
using System.Collections.Generic;
using System.Text;

namespace BS.WEB.TagModelFactory
{
    public class TagModelFactory : IModelFactory<TagPageViewModel, TagDetailsDTO>
    {
        public TagPageViewModel Create(TagDetailsDTO inputType)
        {
            return new TagPageViewModel()
            {
                Id = inputType.Id,
                CreatedOn = inputType.CreatedOn,
                ModifiedOn = inputType.ModifiedOn,
                Name = inputType.Name
            };
        }
    }
}
