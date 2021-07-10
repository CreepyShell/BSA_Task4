using AutoMapper;
using LINQ.Common.DTOModels;
using LINQ.Common.DTOModels.TasksDTO;
using LINQ.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TaskModel = LINQ.DataAccess.Models.Task;

namespace LINQ.BL.Services
{
    public class TaskService : BaseService
    {
        public TaskService(IMapper mapper, LINQDbContext context) : base(context, mapper)
        {
        }
        public async Task<IEnumerable<TaskDTO>> Read()
        {
            var tasks = await _context.Tasks.ToListAsync();
            return _mapper.Map<List<TaskDTO>>(tasks);
        }

        public async Task<TaskDTO> ReadById(int id)
        {
            if (!IsExistElementById(id))
                throw new InvalidOperationException("Can`t find element with this id");
            return _mapper.Map<TaskDTO>(await _context.Tasks.FirstAsync(t => t.Id == id));
        }

        public async Task Create(TaskDTO TaskDTO)
        {
            var task = _mapper.Map<TaskModel>(TaskDTO);
            if (IsExistElementById(TaskDTO.Id))
                throw new InvalidOperationException("toject with this id is already exist");
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TaskDTO>> GetUnexecutedTasks(int userId)
        {
            if (await _context.Users.FirstOrDefaultAsync(u => u.Id == userId) == null)
                throw new InvalidOperationException("can`t find user with this id");
            var rezult = await _context.Tasks.Where(task => task.PerformerId == userId && task.FinishedAt == null).ToListAsync();
            return _mapper.Map<List<TaskDTO>>(rezult);
        }

        public async Task Update(UpdatedTaskDTO newTask, int id)
        {
            if (!IsExistElementById(id))
                throw new System.InvalidOperationException("toject with this id is already exist");

            var update = _context.Tasks.First(t => t.Id == id);
            if (newTask.NewPerformerId != null)
                update.PerformerId = newTask.NewPerformerId.Value;
            if (newTask.NewState != null)
                update.State = newTask.NewState.Value;
            if (newTask.NewDescription != null)
                update.Description = newTask.NewDescription;

            _context.Tasks.Update(update);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            if (!IsExistElementById(id))
                throw new System.InvalidOperationException("Can`t find toject with this id");
            var deleted = _context.Tasks.First(t => t.Id == id);
            _context.Tasks.Remove(deleted);
            await _context.SaveChangesAsync();
        }

        private bool IsExistElementById(int id) => _context.Tasks.Any(t => t.Id == id);
    }
}
