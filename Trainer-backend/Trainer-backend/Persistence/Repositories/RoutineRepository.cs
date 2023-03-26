using Microsoft.EntityFrameworkCore;
using Trainer_backend.Model;

namespace Trainer_backend.Persistence.Repositories
{
    public class RoutineRepository : Repository<Routine>
    {
        public static RoutineRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new(() => new RoutineRepository());
                }

                return _instance.Value;
            }
        }

        private static Lazy<RoutineRepository>? _instance;

        public RoutineRepository() { }


        public async Task<IEnumerable<Routine>> Get()
        {
            await using var db = new DatabaseContext();
            var item = db.Routines
                .Include(p => p.WorkSets)
                .ThenInclude(p => p.Sets)
                .ToList();
            return item;
        }

        public async Task<Routine> GetRoutineById(int id)
        {
            await using var db = new DatabaseContext();
            var item = db.Routines.Where(p => p.Id == id).Include(p => p.WorkSets).ThenInclude(p => p.Sets).FirstOrDefault();
            return item;
        }
    }
}
