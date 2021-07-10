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
    public class TeamControllerIntegrationTests : BaseIntegrationTest
    {

        public TeamControllerIntegrationTests() : base()
        {

        }

        [Fact]
        public async Task GetTeamById_WhenIdIsNotExist_ThenNotFoundResponce()
        {
            int id = -1;

            HttpResponseMessage response = await client.GetAsync($"api/Teams/{id}");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
        [Fact]
        public async Task CreateTeam_WhenAllRight_ThanCreateTeamInDb()
        {
            TeamDTO Team = GetTeam();

            await client.PostAsync("api/Teams", new StringContent(JsonConvert.SerializeObject(Team), Encoding.UTF8, "application/json"));
            HttpResponseMessage responce = await client.GetAsync("api/Teams");
            TeamDTO returnedTeam = JsonConvert.DeserializeObject<List<TeamDTO>>(await responce.Content.ReadAsStringAsync()).First(t => t.Name == Team.Name);

            Assert.NotNull(returnedTeam);
            await client.DeleteAsync($"api/Teams/{returnedTeam.Id}");
        }

        [Fact]
        public async Task DeleteTeam_WhenIdIsNotExist_ThanNotFoundResponce()
        {
            int id = -1;

            HttpResponseMessage message = await client.DeleteAsync($"api/Teams/{id}");

            Assert.Equal(HttpStatusCode.BadRequest, message.StatusCode);
        }
        [Fact]
        public async Task UpdateTeam_WhenNameIsChanged_ThanTeamHaveNewName()
        {
            TeamDTO Team = GetTeam();
            string newName = "new desctioption";

            await client.PostAsync("api/Teams", new StringContent(JsonConvert.SerializeObject(Team), Encoding.UTF8, "application/json"));
            HttpResponseMessage message = await client.GetAsync("api/Teams");
            int updatedTeamId = JsonConvert.DeserializeObject<List<TeamDTO>>(await message.Content.ReadAsStringAsync()).FirstOrDefault(t => t.Name == Team.Name).Id;
            HttpResponseMessage update = await client.PutAsync($"api/Teams/{updatedTeamId}", new StringContent("{" + $"\"NewName\":\"{newName}\"" + "}", Encoding.UTF8, "application/json"));
            HttpResponseMessage responseMessage = await client.GetAsync($"api/Teams/{updatedTeamId}");
            TeamDTO updatedTeam = JsonConvert.DeserializeObject<TeamDTO>(await responseMessage.Content.ReadAsStringAsync());

            Assert.Equal(newName, updatedTeam.Name);

            await client.DeleteAsync($"api/Teams/{updatedTeamId}");
        }

        private TeamDTO GetTeam() => new TeamDTO()
        {
            Name = "Test",
            CreatedAt = new System.DateTime(2000, 1, 1)
        };
    }
}