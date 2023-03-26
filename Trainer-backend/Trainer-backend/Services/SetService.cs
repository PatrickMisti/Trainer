using Microsoft.EntityFrameworkCore;
using Trainer_backend.Model;
using Trainer_backend.Persistence;
using Trainer_backend.Persistence.Repositories;

namespace Trainer_backend.Services
{
    public class SetService : ISetService
    {
        
        private SetRepository _repo;

        public SetService()
        {
            _repo = SetRepository.Instance;
        }
        public async Task<IEnumerable<Set>> GetAllSets()
        {
            return await _repo.Get();
        }

        public async Task<bool> Save(Set set)
        {
            return await _repo.Create(set);
        }

        public async Task<bool> DeleteById(int id)
        {
            return await _repo.DeleteById(id) > 0;
        }

        public async Task<bool> DeleteSet(Set set)
        {
            return await _repo.Delete(set) > 0;
        }

        public Task<bool> DeleteAllSets()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateSet(Set set)
        {
            return await _repo.Update(set) > 0;
        }
    }
}
