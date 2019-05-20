using BS.Data.Models.Abstract.EntityBase;
using BS.Data.Models.Abstract.Tag;
using System;
using System.Collections.Generic;
using System.Text;

namespace BS.Data.Models.Abstract.BlogPost
{
   public interface IBlogPost : IEntityBase
    {
        string Title { get; set; }

        string CreatedBy { get; set; }

        string LastEditedBy { get; set; }

        string Content { get; set; }

       
    }
}
