using BS.Data.Models.Abstract.EntityBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace BS.Data.Models.Abstract.Author
{
    public interface IAuthor : IEntityBase
    {
        string AppUserId { get; set; }
    }
}
