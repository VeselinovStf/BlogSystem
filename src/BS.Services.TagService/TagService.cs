using BS.Data.EntityRepository.Abstract;
using BS.Data.Models;
using BS.Services.ModelFactory.Abstract;
using BS.Services.ServiceValidator;
using BS.Services.TagService.Abstract;
using BS.Services.TagService.ModelDTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace BS.Services.TagService
{
    public class TagService : ITagService
    {
        private readonly IEntityIntGetId<IEnumerable<Tag>> tagRepository;
        private readonly IServiceModelFactory<IEnumerable<TagDetailsDTO>, IEnumerable<Tag>> tagListModelFactory;

        public TagService(IEntityIntGetId<IEnumerable<Tag>> tagRepository,
             IServiceModelFactory<IEnumerable<TagDetailsDTO>, IEnumerable<Tag>> tagListModelFactory)
        {
            this.tagRepository = tagRepository;
            this.tagListModelFactory = tagListModelFactory;
        }
        public async Task<IEnumerable<TagDetailsDTO>> GetAll(int id)
        {
            ServiceValidator.ServiceValidator.IsLessThanOne(id, "Id can't be less then 1.");

           
            var tags = await this.tagRepository.Get(id);

            ServiceValidator.ServiceValidator.IsNull(tags, "Can't find Blog to edin.");

            var serviceModel = this.tagListModelFactory.Create(tags);

            ServiceValidator.ServiceValidator.IsNull(serviceModel, "Model is null");

            return serviceModel;
           
        }
    }
}
