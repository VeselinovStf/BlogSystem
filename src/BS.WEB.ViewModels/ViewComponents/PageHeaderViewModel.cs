using BS.WEB.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BS.WEB.ViewModels.ViewComponents
{
    public class PageHeaderViewModel : IBasePageViewModel
    {
        public string PageTitle { get; set; }
        public string BackgroundImage { get; set; }
        public string HeaderTitle { get; set; }
    }
}
