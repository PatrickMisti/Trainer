using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trainer_backend.Model;

namespace Trainer_backend.Persistence.Configuration
{
    public class SetConfiguration : TableConfiguration<Set>
    {
        public override void Configuration(EntityTypeBuilder<Set> builder)
        {

        }
    }
}
