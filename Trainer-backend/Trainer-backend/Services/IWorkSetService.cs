using Trainer_backend.Model;

namespace Trainer_backend.Services
{
    public interface IWorkSetService
    {
        Task<List<WorkSet>> GetAllWorkSets();
        Task<bool> Save(WorkSet workSet);
        Task<WorkSet> GetWorkSetById(int id);
        Task<WorkSet> GetWorkSetByName(string name);
        Task<bool> DeleteWorkSet(WorkSet workSet);
        Task<bool> DeleteWorkSetById(int id);

        Task<bool> UpdateWorkSet(WorkSet workSet);
    }
}
