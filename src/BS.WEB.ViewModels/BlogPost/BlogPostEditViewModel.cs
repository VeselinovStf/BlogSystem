using BS.WEB.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BS.WEB.ViewModels.BlogPost
{
   public class BlogPostEditViewModel : IBasePageViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }
        public string PageTitle { get; set; }
        public string BackgroundImage { get; set; }
        public string HeaderTitle { get; set; }
    }
}
