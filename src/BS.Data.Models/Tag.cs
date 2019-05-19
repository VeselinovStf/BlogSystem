
using BS.Data.Models.Abstract.Tag;
using System;
using System.Collections.Generic;
using System.Text;

namespace BS.Data.Models
{
    public class Tag : ITagable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public BlogPostTag BlogPostTag { get; set; }
    }
}
