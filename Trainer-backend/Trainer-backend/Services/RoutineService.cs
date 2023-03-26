using Trainer_backend.Model;
using Trainer_backend.Persistence.Repositories;

namespace Trainer_backend.Services
{
    public class RoutineService : IRoutineService
    {
        private RoutineRepository _repo;

        public RoutineService() {  _repo = RoutineRepository.Instance; }

        public async Task<bool> DeleteRoutineById(int id)
        {
            return await _repo.DeleteById(id) > 0;
        }

        public async Task<List<Routine>> GetAllRoutines()
        {
            return (await _repo.Get()).ToList();
        }

        public async Task<Routine> GetRoutine(int id)
        {
            return await _repo.GetById(id);
        }

        public async Task<bool> UpdateRoutine(Routine routine)
        {
            return await _repo.Update(routine) > 0;
        }

        public async Task<bool> Save(Routine routine)
        {
            return await _repo.Create(routine);
        }
    }
}
