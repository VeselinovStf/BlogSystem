using BS.WEB.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BS.WEB.ViewModels.Tag
{
    public class TagEditViewModel : IBasePageViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string PageTitle { get; set; }
        public string BackgroundImage { get; set; }
        public string HeaderTitle { get; set; }
    }
}
