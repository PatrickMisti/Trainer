using Trainer_backend.Model;

namespace Trainer_backend.Services
{
    public interface IRoutineService
    {
        Task<List<Routine>> GetAllRoutines();
        Task<Routine> GetRoutine(int id);
        Task<bool> UpdateRoutine(Routine routine);
        Task<bool> DeleteRoutineById(int id);

        Task<bool> Save(Routine routine);
    }
}
