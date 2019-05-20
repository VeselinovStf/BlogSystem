using BS.Data.EFContext.ModelConfig.Abstract;
using BS.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace BS.Data.EFContext.ModelsConfig
{
    public class AuthorConfig : IEFModelConfig<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasMany(a => a.BlogPosts)
                .WithOne(p => p.Author)
                .HasForeignKey(p => p.AuthorId);

            builder.HasOne(a => a.AppUser)
                .WithOne();
        }
    }
}
