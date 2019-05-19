using BS.Data.EFContext.ModelConfig.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace BS.Data.EFContext.ModelsConfig
{
    public class AuthorConfig : IEFModelConfig<AuthorConfig>
    {
        public void Configure(EntityTypeBuilder<AuthorConfig> builder)
        {
            throw new NotImplementedException();
        }
    }
}
