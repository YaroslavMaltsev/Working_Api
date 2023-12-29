using Microsoft.AspNetCore.Mvc;
using Working_Api.Domain.DTOs;
using Working_Api.Services.Implementation;
using Working_Api.Services.Interface;

namespace Working_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController(IProjectService projectService) : ControllerBase
    {
        private readonly IProjectService _projectService = projectService;

        [HttpPut]
        [Route("{id:int}" , Name = "UpdateImage")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> UpdateImage(int id , UpdateFileDTO updateFileDTO)
        {
            var project = await _projectService.UpdateImage(id, updateFileDTO);

            return Ok(project);
        }

        [HttpDelete]
        [Route("ProjectDeleteAll")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteAll()
        {
            var projectDelete = await _projectService.DeleteAll();

            if (projectDelete.StatusCode == 404)
                return NotFound(projectDelete.Description);

            if (projectDelete.StatusCode == 500)
                return Problem(projectDelete.Description);

            return NoContent();
        }
        [HttpDelete]
        [Route("{id:int}", Name = "ProjectDelete")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(int id)
        {
            var project = await _projectService.Delete(id);

            if (project.StatusCode == 404)
                return NotFound(project.Description);

            if (project.StatusCode == 400)
                return BadRequest(project.Description);

            if (project.StatusCode == 500)
                return Problem(project.Description);

            return NoContent();
        }

        [HttpPost]
        [Route("ProjectService")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Create([FromQuery] ProjectDTO projectDTO)
        {
            var project = await _projectService.Create(projectDTO);

            if (project.StatusCode == 404)
                return NotFound(project.Description);

            if (project.StatusCode == 500)
                return Problem(project.Description);

            return NoContent();
        }

        [HttpGet]
        [Route("{id:int}", Name = "GetProjectId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetProjectById(int id)
        {
            var project = await _projectService.GetProject(id);

            if (project.StatusCode == 400)
                return BadRequest(project);

            if (project.StatusCode == 404)
                return NotFound(project);

            if (project.StatusCode == 500)
                return Problem(project.Description);

            return Ok(project);
        }

        [HttpGet]
        [Route("GetServiceAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetProjectAll()
        {
            var projects = await _projectService.GetProjects();

            if (projects.StatusCode == 404)
                return NotFound(projects);

            if (projects.StatusCode == 500)
                return Problem(projects.Description);

            return Ok(projects);
        }
    }
}
