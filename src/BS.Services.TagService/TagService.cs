using BS.Data.EntityRepository.Abstract;
using BS.Data.Models;
using BS.Services.ModelFactory.Abstract;
using BS.Services.ServiceValidator;
using BS.Services.TagService.Abstract;
using BS.Services.TagService.ModelDTO;
using DateTimeWrapper.Abstract;
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
        private readonly IEntityAddRepository<BlogPostTag> blogPostTagRepository;
        private readonly IEntityAddReturnRepository<Tag> tagAddReturnRepository;
        private readonly IServiceModelFactory<TagDetailsDTO, Tag> tagModelFactory;
        private readonly IServiceModelFactory<TagSetDTO, IEnumerable<Tag>> tagListModelFactory;
        private readonly IDateTimeWrapper dateTimeProvider;

        public TagService(
            IEntityIntGetId<IEnumerable<Tag>> tagIdRepository,
            IEntityRepository<Tag> tagRepository,
            IEntityAddRepository<BS.Data.Models.BlogPostTag> blogPostTagRepository,
            IEntityAddReturnRepository<Tag> tagAddReturnRepository,
            IServiceModelFactory<TagDetailsDTO, Tag> tagModelFactory,
             IServiceModelFactory<TagSetDTO, IEnumerable<Tag>> tagListModelFactory,
             IDateTimeWrapper dateTimeProvider)
        {
            this.tagIdRepository = tagIdRepository;
            this.tagRepository = tagRepository;
            this.blogPostTagRepository = blogPostTagRepository;
            this.tagAddReturnRepository = tagAddReturnRepository;
            this.tagModelFactory = tagModelFactory;
            this.tagListModelFactory = tagListModelFactory;
            this.dateTimeProvider = dateTimeProvider;
        }

        public async Task Create(int id, string name, int blogId)
        {
            ServiceValidator.ServiceValidator.IsLessThanOne(id, "Id can't be less then 1.");
            
            ServiceValidator.ServiceValidator.IsStringValid(name, "Tag name can't be null or white space.");
           

            var newTag = new Tag()
            {
                Name = name,
                CreatedOn = this.dateTimeProvider.Now(),
                ModifiedOn = this.dateTimeProvider.Now()
            };

            ServiceValidator.ServiceValidator.IsNull(newTag, "Object creation fails.");

            try
            {
                var createdTag = await this.tagAddReturnRepository.Add(newTag);

                ServiceValidator.ServiceValidator.IsNull(createdTag, "Tag Object creation fails.");
                ServiceValidator.ServiceValidator.IsLessThanOne(createdTag.Id, "Id can't be less then 1.");

                var blogPostTag = new BlogPostTag()
                {
                    BlogPostId = id,
                    TagId = createdTag.Id
                };

                ServiceValidator.ServiceValidator.IsNull(blogPostTag, "Object creation fails.");

                await this.blogPostTagRepository.Add(blogPostTag);

            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException($"Db Update Exception : {ex.Message} : {ex.InnerException.Message}", ex.InnerException);
            }
            catch (Exception ex)
            {

                throw new InvalidOperationException("Can't Create Tag.");
            }

        }

        public async Task Edit(int id, int tagId, string name, string userName)
        {
            ServiceValidator.ServiceValidator.IsLessThanOne(id, "Id can't be less then 1.");
            ServiceValidator.ServiceValidator.IsLessThanOne(tagId, "Id can't be less then 1.");
            ServiceValidator.ServiceValidator.AreEqual(id, tagId, "Id and Blog Id are not the same.");
            ServiceValidator.ServiceValidator.IsStringValid(name, "Tag name can't be null or white space.");         
            ServiceValidator.ServiceValidator.IsStringValid(userName, "Editor name can't be null or white space.");

            try
            {
                var tag = await this.tagRepository.Get(tagId);

                ServiceValidator.ServiceValidator.IsNull(tag, "Can't find Tag to edin.");

               
                tag.Name = name;
                tag.ModifiedOn = this.dateTimeProvider.Now();
                
                await this.tagRepository.Update(tag);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new ArgumentException(ex.Message, ex.InnerException);
            }
        }

        public async Task<TagDetailsDTO> Get(int? id)
        {
            ServiceValidator.ServiceValidator.IsNull(id, "Id can't be null.");

            var repoCall = await this.tagRepository.Get(id);

            ServiceValidator.ServiceValidator.IsNull(repoCall, "Can't find Blog Post with this id.");

            var serviceModel = this.tagModelFactory.Create(repoCall);

            return serviceModel;
        }

        public async Task<TagSetDTO> GetAll(int id)
        {
            ServiceValidator.ServiceValidator.IsLessThanOne(id, "Id can't be less then 1.");

           
            var tags = await this.tagIdRepository.Get(id);

            ServiceValidator.ServiceValidator.IsNull(tags, "Can't find Blog to edin.");

            var serviceModel = this.tagListModelFactory.Create(tags);

            ServiceValidator.ServiceValidator.IsNull(serviceModel, "Model is null");

            serviceModel.BlogPostId = id;

            return serviceModel;
           
        }

        public async Task Remove(int id)
        {
            ServiceValidator.ServiceValidator.IsNull(id, "Id can't be null.");

            var repoCall = await this.tagRepository.Get(id);

            repoCall.IsDeleted = true;

            await this.tagRepository.Update(repoCall);
        }
    }
}
