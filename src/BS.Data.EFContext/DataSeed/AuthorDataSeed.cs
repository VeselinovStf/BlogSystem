using BS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BS.Data.EFContext.DataSeed
{
    public class AuthorDataSeed
    {
        
        public static Author[] SeedData()
        {
               var authors = new Author[]
                {
                    new Author()
                    {
                         Id = 1,
                         AppUserId = "33e30ac8-a39b-4979-90a9-9d999e514bd0",
                         CreatedOn = DateTime.Now
                    }
                };


            return authors;
        }
    }
}
