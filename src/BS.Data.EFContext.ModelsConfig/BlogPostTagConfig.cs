using BS.Data.EFContext.ModelConfig.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BS.Data.EFContext.ModelsConfig
{
    public class BlogPostTagConfig : IEFModelConfig<BlogPostTagConfig>
    {
        public void Configure(EntityTypeBuilder<BlogPostTagConfig> builder)
        {
            throw new NotImplementedException();
        }
    }
}
