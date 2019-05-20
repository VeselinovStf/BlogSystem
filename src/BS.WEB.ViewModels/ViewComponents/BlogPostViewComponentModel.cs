using BS.WEB.ViewModels.BlogPost;
using System;
using System.Collections.Generic;
using System.Text;

namespace BS.WEB.ViewModels.ViewComponents
{
   public class BlogPostViewComponentModel
    {
        public IEnumerable<BlogPostViewModel> Posts { get; set; }
        public bool IsPublic { get; set; }
    }
}
