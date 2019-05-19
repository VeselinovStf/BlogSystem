using System;

namespace BS.Data.Models.Abstract.EntityBase
{
    public interface IEntityBase : IDeletable, IModifiable
    {
        int Id { get; set; }
    }
}
