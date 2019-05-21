using BS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BS.Data.EFContext.DataSeed
{
   public class TagDataSeed
    {
        public static Tag[] SeedData()
        {
            var tags = new Tag[]
             {
                    new Tag()
                    {
                         Id = 1,
                         CreatedOn = DateTime.Now,
                          Name = "First Tag"
                    },
                     new Tag()
                    {
                         Id = 2,
                         CreatedOn = DateTime.Now,
                         Name = "Second Tag"
                    }
             };


            return tags;
        }
    }
}
