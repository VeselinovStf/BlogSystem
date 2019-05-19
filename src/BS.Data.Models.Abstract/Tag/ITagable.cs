using BS.Data.Models.Abstract.EntityBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace BS.Data.Models.Abstract.Tag
{
   public interface ITagable : IEntityBase
    {
        string Name { get; set; }
    }
}
