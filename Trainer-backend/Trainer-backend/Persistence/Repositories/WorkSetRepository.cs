using Microsoft.EntityFrameworkCore;
using Trainer_backend.Model;

namespace Trainer_backend.Persistence.Repositories
{
    public class WorkSetRepository : Repository<WorkSet>
    {
        public static WorkSetRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new(() => new WorkSetRepository());
                }

                return _instance.Value;
            }
        }

        private static Lazy<WorkSetRepository>? _instance;

        public WorkSetRepository() { }

        public async Task<IEnumerable<WorkSet>> Get()
        {
            await using var db = new DatabaseContext();/*Include(p => p.Sets)*/
            var i = db.WorkSets.Include(p => p.Sets).ToList();
            return i;
        }

        public async Task<bool> Merge(WorkSet work)
        {
            await using var db = new DatabaseContext();
            var i = await GetById(work.Id);
            work.RoutineId = i.RoutineId;
            return await Update(work) > 0;
        }

    }
}
