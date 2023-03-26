using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trainer_backend.Model;

namespace Trainer_backend.Persistence.Configuration
{
    public class TableConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(p => p.Id);

            Configuration(builder);
        }

        public virtual void Configuration(EntityTypeBuilder<T> builder) { }
    }
}
