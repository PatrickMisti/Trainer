using Serilog;
using Serilog.Core;
using Trainer_backend.Model;

namespace Trainer_backend.Persistence.Repositories
{
    public sealed class SetRepository : Repository<Set>
    {
        public static SetRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new(() => new SetRepository());
                }

                return _instance.Value;
            }
        }

        private static Lazy<SetRepository>? _instance;

        private SetRepository() {}


        public async Task<IEnumerable<Set>> Get()
        {
            return await GetAll();
        }

        public async Task<bool> Merge(Set set)
        {
            var res = await GetById(set.Id);
            set.WorkSetId = res.WorkSetId;
            return await Update(set) > 0;
        }
    }
}
