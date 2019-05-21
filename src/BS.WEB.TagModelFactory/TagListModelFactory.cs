using BS.Services.TagService.ModelDTO;
using BS.WEB.ModelFactory.Abstract;
using BS.WEB.ViewModels.Tag;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BS.WEB.TagModelFactory
{
    public class TagListModelFactory : IModelFactory<TagSetViewModel, TagSetDTO>
    {
        public TagSetViewModel Create(TagSetDTO inputType)
        {
            return new TagSetViewModel()
            {
                Tags = inputType.Tags.Select(t => new TagDetailsViewModel()
                {
                    Id = t.Id,
                    Name = t.Name,
                    CreatedOn = t.CreatedOn,
                    ModifiedOn = t.ModifiedOn
                    
                }),
                 BlogPostId = inputType.BlogPostId
            };
        }
    }
}
