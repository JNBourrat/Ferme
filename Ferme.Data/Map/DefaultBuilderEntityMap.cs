using Ferme.Data.Models.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ferme.Data.Map;

public class DefaultBuilderEntityMap<T> : DefaultBuilderMap<T> where T : EntityBase
{
}

public class DefaultBuilderMap<T> : IEntityTypeConfiguration<T> where T : class
{
    void IEntityTypeConfiguration<T>.Configure(EntityTypeBuilder<T> builder)
    {
        Configure(builder);
    }

    protected virtual void Configure(EntityTypeBuilder<T> builder)
    {
        if (builder is null)
        {
            throw new ArgumentNullException(nameof(builder));
        }

        builder.ToTable(typeof(T).Name);
    }
}
