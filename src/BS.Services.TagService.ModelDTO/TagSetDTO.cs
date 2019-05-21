using System;
using System.Collections.Generic;
using System.Text;

namespace BS.Services.TagService.ModelDTO
{
    public class TagSetDTO
    {
        public int BlogPostId { get; set; }
        public IEnumerable<TagDetailsDTO> Tags { get; set; }
    }
}
