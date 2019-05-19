using BS.Data.EFContext.ModelConfig.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BS.Data.EFContext.ModelsConfig
{
    public class BlogPostConfig : IEFModelConfig<BlogPostConfig>
    {
        public void Configure(EntityTypeBuilder<BlogPostConfig> builder)
        {
            throw new NotImplementedException();
        }
    }
}
