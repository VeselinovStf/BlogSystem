using BS.Data.Models.Abstract.EntityBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace BS.Data.Models.Abstract.BlogPostEditor
{
    public interface IBlogPostEditor : IEntityBase
    {
        string EditorName { get; set; }
    }
}
