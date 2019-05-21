using BS.Services.TagService.ModelDTO;
using BS.WEB.ModelFactory.Abstract;
using BS.WEB.ViewModels.Tag;
using System;
using System.Collections.Generic;
using System.Text;

namespace BS.WEB.TagModelFactory
{
    public class TagEditModelFactory : IModelFactory<TagEditViewModel, TagDetailsDTO>
    {
        public TagEditViewModel Create(TagDetailsDTO inputType)
        {
            return new TagEditViewModel()
            {
                Id = inputType.Id,
                Name = inputType.Name
            };
        }
    }
}
