using System;
using System.Collections.Generic;
using System.Text;

namespace BS.Data.Models.Abstract.EntityBase
{
   public interface IDeletable
    {
        bool IsDeleted { get; set; }

        DateTime? DeletedOn { get; set; }
    }
}
