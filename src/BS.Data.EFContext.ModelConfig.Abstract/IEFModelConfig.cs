using Microsoft.EntityFrameworkCore;
using System;

namespace BS.Data.EFContext.ModelConfig.Abstract
{
    public interface IEFModelConfig<T> : IEntityTypeConfiguration<T> where T : class
    {
    }
}
