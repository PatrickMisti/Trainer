using Trainer_backend.Model;
using Trainer_backend.Persistence.Repositories;

namespace Trainer_backend.Services
{
    public class WorkSetService : IWorkSetService
    {
        private WorkSetRepository _repo;

        public WorkSetService()
        {
            _repo = WorkSetRepository.Instance;
        } 

        public async Task<List<WorkSet>> GetAllWorkSets()
        {
            return (await _repo.Get()).ToList();
        }

        public async Task<bool> Save(WorkSet workSet)
        {
            return await _repo.Create(workSet);
        }

        public async Task<WorkSet> GetWorkSetById(int id)
        {
            return await _repo.GetById(id);
        }

        public Task<WorkSet> GetWorkSetByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteWorkSet(WorkSet workSet)
        {
            return await _repo.Delete(workSet) > 0;
        }

        public async Task<bool> DeleteWorkSetById(int id)
        {
            return await _repo.DeleteById(id) > 0;
        }

        public async Task<bool> UpdateWorkSet(WorkSet workSet)
        {
            return await _repo.Update(workSet) > 0;
        }
    }
}
