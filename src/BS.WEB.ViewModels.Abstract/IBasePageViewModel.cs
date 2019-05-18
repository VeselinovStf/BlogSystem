using System;

namespace BS.WEB.ViewModels.Abstract
{
    public interface IBasePageViewModel
    {
        string  PageTitle{ get; set; }

        string BackgroundImage { get; set; }

        string HeaderTitle { get; set; }
    }
}
