using AutoMapper;
using LINQ.BL.MappingSettings;
using LINQ.BL.Services;
using LINQ.Common.DTOModels;
using LINQ.Common.DTOModels.TeamsDTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace LINQ.BL.Tests
{
    public class TeamServiceTests : IDisposable
    {
        readonly TeamService _TeamService;
        readonly IMapper mapper;
        readonly DataAccess.LINQDbContext dbContext;


        public TeamServiceTests()
        {
            mapper = new Mapper(new MapperConfiguration(conf => conf.AddProfile<MapTeam>()));

            var options = new DbContextOptionsBuilder<DataAccess.LINQDbContext>()
                .UseInMemoryDatabase("Test database")
                .Options;

            dbContext = new DataAccess.LINQDbContext(options);

            _TeamService = new TeamService(mapper, dbContext);
        }

        [Fact]
        public async Task DeleteTeam()
        {
            TeamDTO Team = CreateTeam();

            await _TeamService.Create(Team);
            await _TeamService.Delete(_TeamService.Read().Result.First().Id);

            Assert.Empty(_TeamService.Read().Result);
        }
        [Fact]
        public async Task CreateTeams()
        {
            TeamDTO Team = CreateTeam();

            await _TeamService.Create(Team);

            Assert.NotEmpty(_TeamService.Read().Result);

            dbContext.Teams.RemoveRange(dbContext.Teams);
            await dbContext.SaveChangesAsync();
        }

        [Fact]
        public async Task DeleteTeam_WhenIdIdNotExist_ThenThrowInvalidOperationException()
        {
            TeamDTO Team = CreateTeam();

            await _TeamService.Create(Team);

            await Assert.ThrowsAsync<InvalidOperationException>(() => _TeamService.Delete(_TeamService.Read().Result.First().Id - 1));
            dbContext.Teams.RemoveRange(dbContext.Teams);
            await dbContext.SaveChangesAsync();
        }
        [Fact]
        public async Task UpdateTeam()
        {
            TeamDTO Team = CreateTeam();

            await _TeamService.Create(Team);
            string newDescr = "newUserName";
            UpdatedTeamDTO updatedTeam = new UpdatedTeamDTO() { NewName = newDescr };

            await _TeamService.Update(updatedTeam, _TeamService.Read().Result.First().Id);

            Assert.Equal(newDescr, _TeamService.Read().Result.First().Name);

            dbContext.Teams.RemoveRange(dbContext.Teams);
            await dbContext.SaveChangesAsync();
        }

        [Fact]
        public async Task GetTeamById_WhenIdNotExist_ThenThrowInvalidOperationException()
        {
            TeamDTO Team = CreateTeam();

            await _TeamService.Create(Team);

            await Assert.ThrowsAsync<InvalidOperationException>(() => _TeamService.ReadById(_TeamService.Read().Result.FirstOrDefault().Id - 1));

            dbContext.Teams.RemoveRange(dbContext.Teams);
            await dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            dbContext?.Dispose();
            _TeamService?.Dispose();
        }

        private TeamDTO CreateTeam() => new TeamDTO()
        {
            Name = "Test Team",
            CreatedAt = DateTime.Now
        };
    }
}