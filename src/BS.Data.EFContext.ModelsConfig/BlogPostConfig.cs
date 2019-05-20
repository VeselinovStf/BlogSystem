using BS.Data.EFContext.ModelConfig.Abstract;
using BS.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BS.Data.EFContext.ModelsConfig
{
    public class BlogPostConfig : IEFModelConfig<BlogPost>
    {
        public void Configure(EntityTypeBuilder<BlogPost> builder)
        {
          
        }
    }
}
