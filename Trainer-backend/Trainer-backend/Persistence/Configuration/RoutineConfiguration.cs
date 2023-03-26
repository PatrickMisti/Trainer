using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trainer_backend.Model;

namespace Trainer_backend.Persistence.Configuration
{
    public class RoutineConfiguration : TableConfiguration<Routine>
    {
        public override void Configuration(EntityTypeBuilder<Routine> builder)
        {
            builder
                .HasMany(p => p.WorkSets)
                .WithOne()
                .HasForeignKey(p => p.RoutineId);
        }
    }
}
