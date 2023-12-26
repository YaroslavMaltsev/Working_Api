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

        [HttpPost]
        public async Task<ActionResult> Create([FromQuery] ServiceDTO serviceDTO)
        {
            await _serviceService.Create(serviceDTO);
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

            return Ok(service);
        }

        [HttpGet]
        [Route("GetServiceAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetServiceAll()
        {
            var service = await _serviceService.GetServices();

            if (service.StatusCode == 404)
                return NotFound(service);

            return Ok(service);
        }

    }
}
