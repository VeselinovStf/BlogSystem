using System;
using System.Collections.Generic;
using System.Text;

namespace BS.WEB.ViewModels.Tag
{
   public class TagDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
