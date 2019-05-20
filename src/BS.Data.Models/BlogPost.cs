using BS.Data.Models.Abstract.BlogPost;
using BS.Data.Models.Abstract.Tag;
using System;
using System.Collections.Generic;
using System.Text;

namespace BS.Data.Models
{
    public class BlogPost : IBlogPost
    {
        public BlogPost()
        {
           
            this.BlogPostTag = new HashSet<BlogPostTag>();
        }

        public int Id { get; set; }
        public string Title{ get; set; }
        public string CreatedBy{ get; set; }
        public string LastEditedBy{ get; set; }
        public string Content{ get; set; }            
        public bool IsDeleted{ get; set; }
        public DateTime? DeletedOn{ get; set; }
        public DateTime? CreatedOn{ get; set; }
        public DateTime? ModifiedOn{ get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public ICollection<BlogPostTag> BlogPostTag { get; set; }
    }
}
