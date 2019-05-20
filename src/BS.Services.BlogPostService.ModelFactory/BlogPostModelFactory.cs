﻿using BS.Data.Models;
using BS.Services.BlogPostService.ModelDTO;
using BS.Services.ModelFactory.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BS.Services.BlogPostService.ModelFactory
{
   public class BlogPostModelFactory : IServiceModelFactory<BlogPostDTO, BlogPost>
    {
        public BlogPostDTO Create(BlogPost inputType)
        {
            var model = new BlogPostDTO()
            {

                Id = inputType.Id,
                Author = inputType.Author.AppUser.UserName,
                BlogPostTags = inputType.BlogPostTag.Select(t => new TagDTO()
                {
                    Name = t.Tag.Name
                }).ToList(),
                Content = inputType.Content,
                CreatedBy = inputType.CreatedBy,
                CreatedOn = inputType.CreatedOn,
                LastEditedBy = inputType.LastEditedBy,
                ModifiedOn = inputType.ModifiedOn,
                Title = inputType.Title


            };

            return model;
        }
    }
}