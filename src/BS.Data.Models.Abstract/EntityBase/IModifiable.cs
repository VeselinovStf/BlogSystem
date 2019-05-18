using System;
using System.Collections.Generic;
using System.Text;

namespace BS.Data.Models.Abstract.EntityBase
{
    public interface IModifiable
    {
        DateTime? CreatedOn { get; set; }

        DateTime? ModifiedOn { get; set; }
    }
}
