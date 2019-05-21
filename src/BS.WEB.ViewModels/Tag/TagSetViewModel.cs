using BS.WEB.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BS.WEB.ViewModels.Tag
{
   public class TagSetViewModel : IBasePageViewModel
    {
        public IEnumerable<TagDetailsViewModel> Tags { get; set; }
        public string PageTitle { get; set; }
        public string BackgroundImage { get; set; }
        public string HeaderTitle { get; set; }
    }
}
