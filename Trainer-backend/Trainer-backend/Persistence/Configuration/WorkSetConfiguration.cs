using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trainer_backend.Model;

namespace Trainer_backend.Persistence.Configuration
{
    public class WorkSetConfiguration : TableConfiguration<WorkSet>
    {
        public override void Configuration(EntityTypeBuilder<WorkSet> builder)
        {
            builder
                .HasMany(p => p.Sets)
                .WithOne()
                .HasForeignKey(k => k.WorkSetId);

            builder.Ignore(i => i.RoutineId);
        }
    }
}
