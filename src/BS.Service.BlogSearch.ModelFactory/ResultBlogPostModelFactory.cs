using BS.Data.Models;
using BS.Service.BlogSearchService.DTO;
using BS.Services.BlogPostService.ModelDTO;
using BS.Services.ModelFactory.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BS.Service.BlogSearch.ModelFactory
{
    public class ResultBlogPostModelFactory : IServiceListModelFactory<SearchBlogPostResultDTO, IEnumerable<BlogPost>>
    {
        public IEnumerable<SearchBlogPostResultDTO> Create(IEnumerable<BlogPost> inputType)
        {
            return inputType.Select(m => new SearchBlogPostResultDTO()
            {
                Id = m.Id,
                Author = m.Author.AppUser.UserName,
                BlogPostTags = m.BlogPostTag.Where(t => !t.Tag.IsDeleted).Select(t => new SearchTagResultDTO()
                {
                    Name = t.Tag.Name
                }).ToList(),
                Content = m.Content,
                CreatedBy = m.CreatedBy,
                CreatedOn = m.CreatedOn,
                LastEditedBy = m.PostEditors.OrderBy(p => p.CreatedOn).First().EditorName,
                ModifiedOn = m.ModifiedOn,
                Title = m.Title
            });
        }
    }
}
