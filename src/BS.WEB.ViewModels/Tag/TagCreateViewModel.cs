﻿using BS.WEB.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BS.WEB.ViewModels.Tag
{
    public class TagCreateViewModel : IBasePageViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int BlogPostId { get; set; }
        public string PageTitle { get; set; }
        public string BackgroundImage { get; set; }
        public string HeaderTitle { get; set; }

        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
