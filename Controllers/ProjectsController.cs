using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Session2.Models;
using Session2.Services;

namespace Session2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;
        private readonly IMapper _mapper;

        public ProjectController(IProjectService projectService, IMapper mapper)
        {
            _projectService = projectService;
            _mapper = mapper;
        }

        // GET api/projects
        [HttpGet]
        public ActionResult<IEnumerable<ProjectDto>> GetAllProjects()
        {
            var projects = _projectService.GetAllProjects();
            var projectDtos = _mapper.Map<IEnumerable<ProjectDto>>(projects);
            return Ok(projectDtos);
        }

        // GET api/projects/{id}
        [HttpGet("{id}")]
        public ActionResult<ProjectDto> GetProjectById(int id)
        {
            var project = _projectService.GetProjectById(id);
            if (project == null)
                return NotFound();

            var projectDto = _mapper.Map<ProjectDto>(project);
            return Ok(projectDto);
        }

        // POST api/projects
        [HttpPost]
        public IActionResult CreateProject(ProjectDto projectDto)
        {
            var project = _mapper.Map<Project>(projectDto);
            _projectService.AddProject(project);
            return Ok();
        }

        // PUT api/projects/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateProject(int id, ProjectDto projectDto)
        {
            var existingProject = _projectService.GetProjectById(id);
            if (existingProject == null)
                return NotFound();

            _mapper.Map(projectDto, existingProject);
            _projectService.UpdateProject(existingProject);
            return Ok();
        }

        // DELETE api/projects/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteProject(int id)
        {
            var existingProject = _projectService.GetProjectById(id);
            if (existingProject == null)
                return NotFound();

            _projectService.DeleteProject(id);
            return Ok();
        }
    }
}

        
