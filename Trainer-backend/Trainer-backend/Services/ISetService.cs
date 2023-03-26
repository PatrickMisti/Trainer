using Trainer_backend.Model;

namespace Trainer_backend.Services
{
    public interface ISetService
    {
        Task<IEnumerable<Set>> GetAllSets();

        Task<bool> Save(Set set);

        Task<bool> DeleteById(int id);

        Task<bool> DeleteSet(Set set);

        Task<bool> DeleteAllSets();

        Task<bool> UpdateSet(Set set);
    }
}
