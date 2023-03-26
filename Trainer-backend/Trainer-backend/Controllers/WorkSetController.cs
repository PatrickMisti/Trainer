using Microsoft.AspNetCore.Mvc;
using Trainer_backend.Model;
using Trainer_backend.Services;

namespace Trainer_backend.Controllers
{
    [ApiController]
    [Route("api")]
    public class WorkSetController : Controller
    {
        private IWorkSetService _service;

        public WorkSetController(IWorkSetService service)
        {
            try
            {
                _service = service;
            }
            catch (Exception ex)
            {
                throw new HttpRequestException(ex.Message);
            }
        }

        [Route("workset")]
        [HttpGet]
        public async Task<IEnumerable<WorkSet>> Get()
        {
            try
            {
                return await _service.GetAllWorkSets();
            }
            catch (Exception ex)
            {
                throw new HttpRequestException(ex.Message);
            }
        }

        [Route("workset/create")]
        [HttpPut]
        public async Task<bool> Create(WorkSet set)
        {
            try
            {
                return await _service.Save(set);
            }
            catch (Exception e)
            {
                throw new HttpRequestException(e.Message);
            }
        }

        [Route("workset/{id}")]
        [HttpGet]
        public async Task<WorkSet> GetById(int id)
        {
            try
            {
                return await _service.GetWorkSetById(id);
            }
            catch (Exception ex)
            {
                throw new HttpRequestException(ex.Message);
            }
        }

        [Route("workset/{id}")]
        [HttpDelete]
        public async Task<bool> DeleteById(int id)
        {
            try
            {
                return await _service.DeleteWorkSetById(id);
            }
            catch (Exception e)
            {
                throw new HttpRequestException(e.Message);
            }
        }

        [Route("workset")]
        [HttpDelete]
        public async Task<bool> Delete(WorkSet workSet)
        {
            try
            {
                return await _service.DeleteWorkSet(workSet);
            }
            catch (Exception e)
            {
                throw new HttpRequestException(e.Message);
            }
        }

        [Route("workset/update")]
        [HttpPost]
        public async Task<bool> Update(WorkSet workSet)
        {
            try
            {
                return await _service.UpdateWorkSet(workSet);
            }
            catch (Exception e)
            {
                throw new HttpRequestException(e.Message);
            }
        }
    }
}
