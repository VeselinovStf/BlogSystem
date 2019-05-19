using System;
using System.Collections.Generic;
using System.Text;

namespace BS.Data.Models.Abstract.Tag
{
   public interface ITagableList
    {
        ICollection<ITagable> KeywordsList { get; set; }
    }
}
