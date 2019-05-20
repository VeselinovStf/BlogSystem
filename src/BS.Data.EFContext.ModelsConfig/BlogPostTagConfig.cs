using BS.Data.EFContext.ModelConfig.Abstract;
using BS.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BS.Data.EFContext.ModelsConfig
{
    public class BlogPostTagConfig : IEFModelConfig<BlogPostTag>
    {
        public void Configure(EntityTypeBuilder<BlogPostTag> builder)
        {
            builder.HasKey(t => new { t.BlogPostId, t.TagId });

            builder.HasOne(pt => pt.BlogPost)
           .WithMany(p => p.BlogPostTag)
           .HasForeignKey(pt => pt.BlogPostId);

            builder.HasOne(pt => pt.Tag)
                .WithMany(t => t.BlogPostTag)
                .HasForeignKey(pt => pt.TagId);
        }
    }
}
