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
        private readonly IEntityIntGetId<IEnumerable<Tag>> tagIdRepository;
        private readonly IEntityRepository<Tag> tagRepository;
        private readonly IServiceModelFactory<TagDetailsDTO, Tag> tagModelFactory;
        private readonly IServiceModelFactory<IEnumerable<TagDetailsDTO>, IEnumerable<Tag>> tagListModelFactory;

        public TagService(IEntityIntGetId<IEnumerable<Tag>> tagIdRepository,
            IEntityRepository<Tag> tagRepository,
            IServiceModelFactory<TagDetailsDTO, Tag> tagModelFactory,
             IServiceModelFactory<IEnumerable<TagDetailsDTO>, IEnumerable<Tag>> tagListModelFactory)
        {
            this.tagIdRepository = tagIdRepository;
            this.tagRepository = tagRepository;
            this.tagModelFactory = tagModelFactory;
            this.tagListModelFactory = tagListModelFactory;
        }

        public async Task<TagDetailsDTO> Get(int? id)
        {
            ServiceValidator.ServiceValidator.IsNull(id, "Id can't be null.");

            var repoCall = await this.tagRepository.Get(id);

            ServiceValidator.ServiceValidator.IsNull(repoCall, "Can't find Blog Post with this id.");

            var serviceModel = this.tagModelFactory.Create(repoCall);

            return serviceModel;
        }

        public async Task<IEnumerable<TagDetailsDTO>> GetAll(int id)
        {
            ServiceValidator.ServiceValidator.IsLessThanOne(id, "Id can't be less then 1.");

           
            var tags = await this.tagIdRepository.Get(id);

            ServiceValidator.ServiceValidator.IsNull(tags, "Can't find Blog to edin.");

            var serviceModel = this.tagListModelFactory.Create(tags);

            ServiceValidator.ServiceValidator.IsNull(serviceModel, "Model is null");

            return serviceModel;
           
        }
    }
}
