using BS.Data.EFContext.ModelConfig.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BS.Data.EFContext.ModelsConfig
{
    public class TagConfig : IEFModelConfig<TagConfig>
    {
        public void Configure(EntityTypeBuilder<TagConfig> builder)
        {
            throw new NotImplementedException();
        }
    }
}
