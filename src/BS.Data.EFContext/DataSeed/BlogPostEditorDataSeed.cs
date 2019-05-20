using BS.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BS.Data.EFContext.DataSeed
{
    public class BlogPostEditorDataSeed
    {
        public static BlogPostEditor[] SeedData()
        {
            var blogPosts = new BlogPostEditor[]
                {
                    new BlogPostEditor()
                    {
                          Id = 1,
                          BlogPostId = 1,
                          CreatedOn = DateTime.Now,
                           EditorName = "Admin1"

                    }
                };


            return blogPosts;
        }

    }
}
