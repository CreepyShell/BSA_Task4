using AutoMapper;
using LINQ.BL.MappingSettings;
using LINQ.BL.Services;
using LINQ.Common.DTOModels;
using LINQ.Common.DTOModels.TasksDTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace LINQ.BL.Tests
{
    public class TaskServiceTests : IDisposable
    {
        readonly TaskService _taskService;
        readonly IMapper mapper;
        readonly DataAccess.LINQDbContext dbContext;


        public TaskServiceTests()
        {
            mapper = new Mapper(new MapperConfiguration(conf => conf.AddProfile<MapTask>()));

            var options = new DbContextOptionsBuilder<DataAccess.LINQDbContext>()
                .UseInMemoryDatabase("Test task database")
                .Options;

            dbContext = new DataAccess.LINQDbContext(options);

            _taskService = new TaskService(mapper, dbContext);
        }

        [Fact]
        public async Task DeleteTask()
        {
            TaskDTO Task = CreateTask();

            await _taskService.Create(Task);
            await _taskService.Delete(_taskService.Read().Result.First().Id);

            Assert.Empty(_taskService.Read().Result);
        }
        [Fact]
        public async Task GetUnexecutedTasks_WhenIdIsNotExist_ThenThrowInvalidOperationException()
        {
            int id = -1;

            await Assert.ThrowsAsync<InvalidOperationException>(()=> _taskService.GetUnexecutedTasks(id));
        }

        [Fact]
        public async Task GetUnexecutedTasks_WhenAllTasksIsDone_ThenListIsEmpty()
        {
            TaskDTO task1 = CreateTask();
            TaskDTO task2 = CreateTask();
            await _taskService.Create(task1);
            await _taskService.Create(task2);
            DataAccess.Models.User user = new DataAccess.Models.User() { Id = 1 };
            dbContext.Users.Add(user);
            await dbContext.SaveChangesAsync();

            var exctTasks = await _taskService.GetUnexecutedTasks(1);

            Assert.Empty(exctTasks);

            dbContext.Tasks.RemoveRange(dbContext.Tasks);
            dbContext.Users.Remove(user);
            await dbContext.SaveChangesAsync();
        }
        [Fact]
        public async Task CreateTasks()
        {
            TaskDTO Task = CreateTask();

            await _taskService.Create(Task);

            Assert.NotEmpty(_taskService.Read().Result);

            dbContext.Tasks.RemoveRange(dbContext.Tasks);
            await dbContext.SaveChangesAsync();
        }

        [Fact]
        public async Task DeleteTask_WhenIdIdNotExist_ThenThrowInvalidOperationException()
        {
            TaskDTO Task = CreateTask();

            await _taskService.Create(Task);

            await Assert.ThrowsAsync<InvalidOperationException>(() => _taskService.Delete(_taskService.Read().Result.First().Id - 1));
            dbContext.Tasks.RemoveRange(dbContext.Tasks);
            await dbContext.SaveChangesAsync();
        }
        [Fact]
        public async Task UpdateTask()
        {
            TaskDTO Task = CreateTask();

            await _taskService.Create(Task);
            string newDescr = "new updated description";
            UpdatedTaskDTO updatedTask = new UpdatedTaskDTO() { NewDescription = newDescr };

            await _taskService.Update(updatedTask, _taskService.Read().Result.First().Id);

            Assert.Equal(newDescr, _taskService.Read().Result.First().Description);

            dbContext.Tasks.RemoveRange(dbContext.Tasks);
            await dbContext.SaveChangesAsync();
        }

        [Fact]
        public async Task GetTaskById_WhenIdNotExist_ThenThrowInvalidOperationException()
        {
            TaskDTO Task = CreateTask();

            await _taskService.Create(Task);

            await Assert.ThrowsAsync<InvalidOperationException>(() => _taskService.ReadById(_taskService.Read().Result.FirstOrDefault().Id - 1));

            dbContext.Tasks.RemoveRange(dbContext.Tasks);
            await dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            dbContext?.Dispose();
            _taskService?.Dispose();
        }

        private TaskDTO CreateTask() => new TaskDTO()
        {
            Name = "Test Task",
            Description = "descr",
            CreatedAt = DateTime.Now,
            FinishedAt = DateTime.Now.AddDays(7),
            State = 1,
            PerformerId = 1,
            ProjectId = 1
        };
    }
}