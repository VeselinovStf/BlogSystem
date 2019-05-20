using BS.Data.Models.Abstract.BlogPostEditor;
using System;
using System.Collections.Generic;
using System.Text;

namespace BS.Data.Models
{
    public class BlogPostEditor : IBlogPostEditor
    {
        public int Id { get; set; }

        public string EditorName { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public int BlogPostId { get; set; }

        public BlogPost BlogPost { get; set; }
    }
}
