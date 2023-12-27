using Microsoft.AspNetCore.Mvc;
using Working_Api.Domain.DTOs;
using Working_Api.Services.Interface;

namespace Working_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkerController(IWorkerService worcerService) : ControllerBase
    {
        private readonly IWorkerService _workerService = worcerService;

        [HttpDelete]
        [Route("{id:int}", Name = "WorkerDelete")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(int id)
        {
            var workerDelete = await _workerService.Delete(id);

            if (workerDelete.StatusCode == 404)
                return NotFound(workerDelete.Description);

            if (workerDelete.StatusCode == 400)
                return BadRequest(workerDelete.Description);

            if (workerDelete.StatusCode == 500)
                return Problem(workerDelete.Description);

            return NoContent();
        }

        [HttpPost]
        [Route("WorkerService")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Create([FromQuery] WorkerDTO workerDTO)
        {
            var worker = await _workerService.Create(workerDTO);

            if (worker.StatusCode == 404)
                return NotFound(worker.Description);

            if (worker.StatusCode == 500)
                return Problem(worker.Description);

            return NoContent();
        }

        [HttpGet]
        [Route("{id:int}", Name = "GetWorkerId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetServiceById(int id)
        {
            var worker = await _workerService.GetWorker(id);

            if (worker.StatusCode == 400)
                return BadRequest(worker);

            if (worker.StatusCode == 404)
                return NotFound(worker);

            if (worker.StatusCode == 500)
                return Problem(worker.Description);

            return Ok(worker);
        }

        [HttpGet]
        [Route("GetWorkerAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetServiceAll()
        {
            var workes = await _workerService.GetWorkers();

            if (workes.StatusCode == 404)
                return NotFound(workes);

            if (workes.StatusCode == 500)
                return Problem(workes.Description);

            return Ok(workes);
        }

    }
}
