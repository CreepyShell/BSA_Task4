using AutoMapper;
using LINQ.BL.MappingSettings;
using LINQ.BL.Services;
using LINQ.Common.DTOModels;
using LINQ.Common.DTOModels.UsersDTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace LINQ.BL.Tests
{
    public class UserServiceTests : IDisposable
    {
        readonly UserService _UserService;
        readonly IMapper mapper;
        readonly DataAccess.LINQDbContext dbContext;


        public UserServiceTests()
        {
            mapper = new Mapper(new MapperConfiguration(conf => conf.AddProfile<MapUser>()));

            var options = new DbContextOptionsBuilder<DataAccess.LINQDbContext>()
                .UseInMemoryDatabase("Test user database")
                .Options;

            dbContext = new DataAccess.LINQDbContext(options);

            _UserService = new UserService(mapper, dbContext);
        }

        [Fact]
        public async Task DeleteUser()
        {
            UserDTO User = CreateUser();

            await _UserService.Create(User);
            await _UserService.Delete(_UserService.Read().Result.First().Id);

            Assert.Empty(_UserService.Read().Result);
        }
        [Fact]
        public async Task CreateUsers()
        {
            UserDTO User = CreateUser();

            await _UserService.Create(User);

            Assert.NotEmpty(_UserService.Read().Result);

            dbContext.Users.RemoveRange(dbContext.Users);
            await dbContext.SaveChangesAsync();
        }

        [Fact]
        public async Task DeleteUser_WhenIdIdNotExist_ThenThrowInvalidOperationException()
        {
            UserDTO User = CreateUser();

            await _UserService.Create(User);

            await Assert.ThrowsAsync<InvalidOperationException>(() => _UserService.Delete(_UserService.Read().Result.First().Id - 1));
            dbContext.Users.RemoveRange(dbContext.Users);
            await dbContext.SaveChangesAsync();
        }
        [Fact]
        public async Task UpdateUser()
        {
            UserDTO User = CreateUser();

            await _UserService.Create(User);
            string newName = "new Test name";
            UpdatedUserDTO updatedUser = new UpdatedUserDTO() {NewName  = newName };

            await _UserService.Update(updatedUser, _UserService.Read().Result.First().Id);

            Assert.Equal(newName, _UserService.Read().Result.First().FirstName);

            dbContext.Users.RemoveRange(dbContext.Users);
            await dbContext.SaveChangesAsync();
        }

        [Fact]
        public async Task GetUserById_WhenIdNotExist_ThenThrowInvalidOperationException()
        {
            UserDTO User = CreateUser();

            await _UserService.Create(User);

            await Assert.ThrowsAsync<InvalidOperationException>(() => _UserService.ReadById(_UserService.Read().Result.FirstOrDefault().Id - 1));

            dbContext.Users.RemoveRange(dbContext.Users);
            await dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            dbContext?.Dispose();
            _UserService?.Dispose();
        }

        private UserDTO CreateUser() => new UserDTO()
        {
            FirstName = "Test ",
            LastName = "User",
            Email = "UserTest@email.com",
            RegisteredAt = DateTime.Now,
            TeamId = 1,
            BirthDay = new DateTime(2001, 2, 28)
        };
    }
}