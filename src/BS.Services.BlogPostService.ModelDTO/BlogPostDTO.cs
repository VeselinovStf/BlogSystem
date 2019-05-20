using System;
using System.Collections.Generic;

namespace BS.Services.BlogPostService.ModelDTO
{
    public class BlogPostDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string CreatedBy { get; set; }
        public string LastEditedBy { get; set; }
        public string Content { get; set; }
        
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string Author { get; set; }
        public ICollection<TagDTO> BlogPostTags { get; set; }
    }
}
