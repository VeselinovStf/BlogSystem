using BS.WEB.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BS.WEB.ViewModels.BlogPost
{
   public class BlogPostSetViewModel : IBasePageViewModel
    {
        public IEnumerable<BlogPostViewModel> Posts { get; set; }

        public string PageTitle { get; set; }
        public string BackgroundImage { get; set; }
        public string HeaderTitle { get; set; }
    }
}
