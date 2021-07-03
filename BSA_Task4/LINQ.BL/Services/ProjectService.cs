using LINQ.Common.DTOModels;
using LINQ.DataAccess;
using LINQ.DataAccess.Models;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LINQ.BL.Services
{
    public class ProjectService : BaseService
    {
        public ProjectService(IMapper mapper, LINQDbContext context):base(context, mapper)
        {
        }
        public async Task<IEnumerable<ProjectDTO>> Read()
        {
            var projects = await _context.Projects.ToListAsync();
            return _mapper.Map<List<ProjectDTO>>(projects);
        }

        public async Task<ProjectDTO> ReadById(int id)
        {
            if (!IsExistElementById(id))
                throw new System.InvalidOperationException("Can`t find element with this id");
            return _mapper.Map<ProjectDTO>(await _context.Projects.FirstAsync(pr => pr.Id == id));
        }

        public async System.Threading.Tasks.Task Create(ProjectDTO projectDTO)
        {
            var project = _mapper.Map<Project>(projectDTO);
            if (IsExistElementById(projectDTO.Id))
                throw new System.InvalidOperationException("project with this id is already exist");
            _context.Projects.Add(project);
           await _context.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task Update(ProjectDTO newProject, int id)
        {
            var project = _mapper.Map<Project>(newProject);
            if (!IsExistElementById(id)) 
                throw new System.InvalidOperationException("project with this id is already exist");
            var update = _context.Projects.First(pr => pr.Id == id);
            update = project;
            _context.Projects.Update(update);
            await _context.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task Delete(int id)
        {
            if (!IsExistElementById(id)) 
                throw new System.InvalidOperationException("Can`t find project with this id");
            var deleted = _context.Projects.First(pr => pr.Id == id);
            _context.Projects.Remove(deleted);
            await _context.SaveChangesAsync();
        }
        private bool IsExistElementById(int id) => _context.Projects.Any(pr => pr.Id == id);
    }
}
