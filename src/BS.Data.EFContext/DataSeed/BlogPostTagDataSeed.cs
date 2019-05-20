using BS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BS.Data.EFContext.DataSeed
{
   public class BlogPostTagDataSeed
    {
        public static BlogPostTag[] SeedData()
        {
            var blogPostTags = new BlogPostTag[]
                {
                    new BlogPostTag()
                    {
                          BlogPostId = 1,
                           TagId = 1
                    },
                     new BlogPostTag()
                    {
                          BlogPostId = 1,
                          TagId = 2
                    }
                };


            return blogPostTags;
        }

      
    }
}
