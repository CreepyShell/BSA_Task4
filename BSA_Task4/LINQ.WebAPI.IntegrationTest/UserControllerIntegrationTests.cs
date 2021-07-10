using LINQ.Common.DTOModels;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LINQ.WebAPI.IntegrationTest
{
    public class UserControllerIntegrationTests : BaseIntegrationTest
    {

        public UserControllerIntegrationTests() : base()
        {

        }

        [Fact]
        public async Task GetUserById_WhenIdIsNotExist_ThenNotFoundResponce()
        {
            int id = -1;

            HttpResponseMessage response = await client.GetAsync($"api/Users/{id}");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
        [Fact]
        public async Task CreateUser_WhenAllRight_ThanCreateUserInDb()
        {
            UserDTO User = GetUser();

            await client.PostAsync("api/Users", new StringContent(JsonConvert.SerializeObject(User), Encoding.UTF8, "application/json"));
            HttpResponseMessage responce = await client.GetAsync("api/Users");
            UserDTO returnedUser = JsonConvert.DeserializeObject<List<UserDTO>>(await responce.Content.ReadAsStringAsync()).First(t => t.Email == User.Email);

            Assert.NotNull(returnedUser);
            await client.DeleteAsync($"api/Users/{returnedUser.Id}");
        }

        [Fact]
        public async Task DeleteUser_WhenIdIsNotExist_ThanNotFoundResponce()
        {
            int id = -1;

            HttpResponseMessage message = await client.DeleteAsync($"api/Users/{id}");

            Assert.Equal(HttpStatusCode.BadRequest, message.StatusCode);
        }
        [Fact]
        public async Task UpdateUser_WhenNameIsChanged_ThanUserHaveNewName()
        {
            UserDTO User = GetUser();
            string newName = "new desctioption";
            int newTeamiD = 2;

            await client.PostAsync("api/Users", new StringContent(JsonConvert.SerializeObject(User), Encoding.UTF8, "application/json"));
            HttpResponseMessage message = await client.GetAsync("api/Users");
            int updatedUserId = JsonConvert.DeserializeObject<List<UserDTO>>(await message.Content.ReadAsStringAsync()).FirstOrDefault(t => t.Email == User.Email).Id;
            HttpResponseMessage update = await client.PutAsync($"api/Users/{updatedUserId}", 
                new StringContent("{" + $"\"NewName\":\"{newName}\", \"NewTeamiD\":{newTeamiD}" + "}", Encoding.UTF8, "application/json"));
            HttpResponseMessage responseMessage = await client.GetAsync($"api/Users/{updatedUserId}");
            UserDTO updatedUser = JsonConvert.DeserializeObject<UserDTO>(await responseMessage.Content.ReadAsStringAsync());

            Assert.Equal(newName, updatedUser.FirstName);
            Assert.Equal(newTeamiD, updatedUser.TeamId);

            await client.DeleteAsync($"api/Users/{updatedUserId}");
        }

        private UserDTO GetUser() => new UserDTO()
        {
            FirstName = "Test",
            LastName = " user",
            BirthDay = new System.DateTime(1970, 1, 1),
            Email = "test@email.com",
            RegisteredAt = new System.DateTime(2010, 2, 3),
            TeamId = 1
        };
    }
}