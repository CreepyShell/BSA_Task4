using AutoMapper;
using LINQ.BL.MappingSettings;
using LINQ.BL.Services;
using LINQ.Common.DTOModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace LINQ.BL.Tests
{
    public class ProjectServiceTests : IDisposable
    {
        readonly ProjectService _projectService;
        readonly IMapper mapper;
        readonly DataAccess.LINQDbContext dbContext;


        public ProjectServiceTests()
        {
            mapper = new Mapper(new MapperConfiguration(conf => conf.AddProfile<MapProject>()));

            var options = new DbContextOptionsBuilder<DataAccess.LINQDbContext>()
                .UseInMemoryDatabase("Test database")
                .Options;

            dbContext = new DataAccess.LINQDbContext(options);

            _projectService = new ProjectService(mapper, dbContext);
        }

        [Fact]
        public async Task DeleteProject()
        {
            ProjectDTO project = CreateProject();

            await _projectService.Create(project);
            await _projectService.Delete(_projectService.Read().Result.First().Id);

            Assert.Empty(_projectService.Read().Result);
        }
        [Fact]
        public async Task CreateProjects()
        {
            ProjectDTO project = CreateProject();

            await _projectService.Create(project);

            Assert.NotEmpty(_projectService.Read().Result);

            dbContext.Projects.RemoveRange(dbContext.Projects);
            await dbContext.SaveChangesAsync();
        }

        [Fact]
        public async Task DeleteProject_WhenIdIdNotExist_ThenThrowInvalidOperationException()
        {
            ProjectDTO project = CreateProject();

            await _projectService.Create(project);

            await Assert.ThrowsAsync<InvalidOperationException>(() => _projectService.Delete(_projectService.Read().Result.First().Id - 1));
            dbContext.Projects.RemoveRange(dbContext.Projects);
            await dbContext.SaveChangesAsync();
        }
        [Fact]
        public async Task UpdateProject()
        {
            ProjectDTO project = CreateProject();

            await _projectService.Create(project);
            string newDescr = "new updated description";
            UpdatedProjectDTO updatedProject = new UpdatedProjectDTO() { NewDescription = newDescr };

            await _projectService.Update(updatedProject, _projectService.Read().Result.First().Id);

            Assert.Equal(newDescr, _projectService.Read().Result.First().Description);

            dbContext.Projects.RemoveRange(dbContext.Projects);
            await dbContext.SaveChangesAsync();
        }

        [Fact]
        public async Task GetProjectById_WhenIdNotExist_ThenThrowInvalidOperationException()
        {
            ProjectDTO project = CreateProject();

            await _projectService.Create(project);

            await Assert.ThrowsAsync<InvalidOperationException>(() => _projectService.ReadById(_projectService.Read().Result.FirstOrDefault().Id - 1));

            dbContext.Projects.RemoveRange(dbContext.Projects);
            await dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            dbContext?.Dispose();
            _projectService?.Dispose();
        }

        private ProjectDTO CreateProject() => new ProjectDTO()
        {
            Name = "Test project",
            Description = "descr",
            TeamId = 1,
            AuthorId = 1,
            CreatedAt = DateTime.Now,
            Deadline = DateTime.Now.AddDays(18)
        };
    }
}
