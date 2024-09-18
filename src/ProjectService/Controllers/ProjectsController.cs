using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectService.Data;
using ProjectService.DTOs;
using ProjectService.Entities;

namespace ProjectService.Controllers
{
    [ApiController]
    [Route("api/projects")]
    public class ProjectsController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ProjectsController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProjectDto>>> GetAllProjects()
        {
            var projects = await _context.Projects.Include(p => p.Tasks).ToListAsync();

            return _mapper.Map<List<ProjectDto>>(projects);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectDto>> GetProjectById(int id)
        {
            var project = await _context.Projects
                .FirstOrDefaultAsync(x => x.Id == id);
            
            if (project == null) return NotFound();

            return _mapper.Map<ProjectDto>(project);
        }

        [HttpPost]
        public async Task<ActionResult<ProjectDto>> CreateAuction(CreateProjectDto projectDto)
        {
            var project = _mapper.Map<Project>(projectDto);
            // TODO: add current user as CreatedBy
            // project = "test";

            _context.Projects.Add(project);

            var result = await _context.SaveChangesAsync() > 0;

            if (!result) return BadRequest("Could not save changes to the DB");

            return CreatedAtAction(nameof(GetProjectById), 
                new {project.Id}, _mapper.Map<ProjectDto>(project));
        }
    }
}