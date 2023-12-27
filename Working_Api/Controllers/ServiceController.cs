using Microsoft.AspNetCore.Mvc;
using Working_Api.Domain.DTOs;
using Working_Api.Services.Interface;

namespace Working_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceController(IServiceService serviceService) : ControllerBase
    {
        private readonly IServiceService _serviceService = serviceService;

        [HttpDelete]
        [Route("{id:int}", Name = "ServiceDelete")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete (int id)
        {
            var serviceDelete = await _serviceService.Delete(id);

            if (serviceDelete.StatusCode == 404)
                return NotFound(serviceDelete.Description);

            if (serviceDelete.StatusCode == 400)
                return BadRequest(serviceDelete.Description);

            if (serviceDelete.StatusCode == 500)
                return Problem(serviceDelete.Description);

            return NoContent();
        }

        [HttpPost]
        [Route("CreateService")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Create([FromQuery] ServiceDTO serviceDTO)
        {
            var service = await _serviceService.Create(serviceDTO);
            
            if (service.StatusCode == 404)
                return NotFound(service.Description);

            if(service.StatusCode == 500)
                return Problem(service.Description);

            return NoContent();
        }

        [HttpGet]
        [Route("{id:int}", Name = "GetServiceId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetServiceById(int id)
        {
            var service = await _serviceService.GetService(id);

            if (service.StatusCode == 400)
                return BadRequest(service);

            if (service.StatusCode == 404)
                return NotFound(service);

            if (service.StatusCode == 500)
                return Problem(service.Description);

            return Ok(service);
        }

        [HttpGet]
        [Route("GetServiceAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetServiceAll()
        {
            var services = await _serviceService.GetServices();

            if (services.StatusCode == 404)
                return NotFound(services);

            if (services.StatusCode == 500)
                return Problem(services.Description);

            return Ok(services);
        }

    }
}
