using BS.Data.Models.Abstract.Author;
using BS.Identity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BS.Data.Models
{
    public class Author : IAuthor
    {
        public Author()
        {
            this.BlogPosts = new HashSet<BlogPost>();
        }

        public int Id { get; set; }
        public string AppUserId { get; set; }

        public BaseIdentityUser AppUser { get; set ; }

        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public ICollection<BlogPost> BlogPosts  { get; set; }
    }
}
