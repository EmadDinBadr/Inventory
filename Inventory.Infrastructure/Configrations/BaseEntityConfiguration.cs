using Inventory.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Infrastructure.Configrations
{
    public class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseModel
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.ID);

            builder.Property(x => x.CreatedDate)
                   .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(x => x.ModifiedDate);

            builder.Property(x => x.IsDeleted)
                   .HasDefaultValue(false);
            builder.HasQueryFilter(i=> !i.IsDeleted);
        }
    }
}
