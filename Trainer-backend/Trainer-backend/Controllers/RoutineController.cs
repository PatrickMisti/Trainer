using Microsoft.AspNetCore.Mvc;
using Trainer_backend.Model;
using Trainer_backend.Services;

namespace Trainer_backend.Controllers
{
    [ApiController]
    [Route("api")]
    public class RoutineController : Controller
    {
        private IRoutineService _service;

        public RoutineController(IRoutineService service)
        {
            _service = service;
        }

        [Route("routine")]
        [HttpGet]
        public async Task<IEnumerable<Routine>> Get()
        {
            try
            {
                return await _service.GetAllRoutines();
            }
            catch (Exception e)
            {
                throw new HttpRequestException(e.Message);
            }
        }

        [Route("routine/{id}")]
        [HttpGet]
        public async Task<Routine> GetById(int id)
        {
            try
            {
                return await _service.GetRoutine(id);
            }
            catch (Exception e)
            {
                throw new HttpRequestException(e.Message);
            }
        }

        [Route("routine/{id}")]
        [HttpDelete]
        public async Task<bool> DeleteById(int id)
        {
            try
            {
                return await _service.DeleteRoutineById(id);
            }
            catch (Exception e)
            {
                throw new HttpRequestException(e.Message);
            }
        }

        [Route("routine/update")]
        [HttpPost]
        public async Task<bool> Update(Routine routine)
        {
            try
            {
                return await _service.UpdateRoutine(routine);
            }
            catch (Exception e)
            {
                throw new HttpRequestException(e.Message);
            }
        }

        [Route("routine/create")]
        [HttpPut]
        public async Task<bool> Create(Routine routine)
        {
            try
            {
                return await _service.Save(routine);
            }
            catch (Exception e)
            {
                throw new HttpRequestException(e.Message);
            }
        }
    }
}
