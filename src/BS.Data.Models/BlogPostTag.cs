using System;
using System.Collections.Generic;
using System.Text;

namespace BS.Data.Models
{
   public class BlogPostTag
    {
        public int BlogPostId { get; set; }

        public BlogPost BlogPost { get; set; }

        public int TagId { get; set; }

        public Tag Tag { get; set; }
    }
}
