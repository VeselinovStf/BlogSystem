using BS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BS.Data.EFContext.DataSeed
{
    public class BlogPostDataSeed
    {
        public static BlogPost[] SeedData()
        {
            var blogPosts = new BlogPost[]
                {
                    new BlogPost()
                    {
                         Id = 1,
                         AuthorId = 1,
                         Content = "This is a simple post content.",
                         Title = "Demo Post",
                         CreatedBy = "Admin 1",
                         CreatedOn = DateTime.Now,
                         

                    }
                };


            return blogPosts;
        }

       
    }
}
