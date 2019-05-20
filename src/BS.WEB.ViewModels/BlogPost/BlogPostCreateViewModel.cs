using BS.WEB.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BS.WEB.ViewModels.BlogPost
{
   public class BlogPostCreateViewModel : IBasePageViewModel
    {
       
        public string Title { get; set; }
       
        public string Content { get; set; }

       
        public ICollection<TagViewModel> BlogPostTags { get; set; }

        public string PageTitle { get; set; }
        public string BackgroundImage { get; set; }
        public string HeaderTitle { get; set; }
    }
}
