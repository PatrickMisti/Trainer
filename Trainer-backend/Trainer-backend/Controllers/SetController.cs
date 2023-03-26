using Microsoft.AspNetCore.Mvc;
using Trainer_backend.Model;
using Trainer_backend.Services;

namespace Trainer_backend.Controllers
{
    [ApiController]
    [Route("api")]
    public class SetController : Controller
    {
        private readonly ILogger<SetController> _logger;
        ISetService _service;

        public SetController(ISetService service, ILogger<SetController> logger)
        {
            _logger = logger;
            _service = service;
        }

        [Route("set")]
        [HttpGet]
        public async Task<IEnumerable<Set>> GetAll()
        {
            try
            {
                return await _service.GetAllSets();
            } 
            catch (Exception ex)
            {
                throw new HttpRequestException(ex.Message);
            }
        }
        
        [Route("set/create")]
        [HttpPut]
        public async Task<bool> Create(Set set)
        {
            try
            {
                if (set == null)
                    return false;

                return await _service.Save(set);
            } 
            catch (Exception ex)
            {
                throw new HttpRequestException(ex.Message);
            }
        }

        [Route("set/{id}")]
        [HttpDelete]
        public async Task<bool> DeleteById(int id)
        {
            try
            {
                return await _service.DeleteById(id);
            }
            catch (Exception e)
            {
                throw new HttpRequestException(e.Message);
            }
        }

        [Route("set/delete")]
        [HttpDelete]
        public async Task<bool> Delete(Set set)
        {
            try
            {
                return await _service.DeleteSet(set);
            }
            catch (Exception e)
            {
                throw new HttpRequestException(e.Message);
            }
        }

        [Route("set/update")]
        [HttpPost]
        public async Task<bool> Update(Set set)
        {
            try
            {
                return await _service.UpdateSet(set);
            }
            catch (Exception e)
            {
                throw new HttpRequestException(e.Message);
            }
        }
    }
}
