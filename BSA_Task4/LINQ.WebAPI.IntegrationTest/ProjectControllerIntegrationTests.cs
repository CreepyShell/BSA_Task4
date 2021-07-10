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
    public class ProjectControllerIntegrationTests : BaseIntegrationTest
    {

        public ProjectControllerIntegrationTests() : base()
        {

        }

        [Fact]
        public async Task GetProjectById_WhenIdIsNotExist_ThenNotFoundResponce()
        {
            int id = -1;

            HttpResponseMessage response = await client.GetAsync($"api/Projects/{id}");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
        [Fact]
        public async Task CreateProject_WhenAllRight_ThanCreateProjectInDb()
        {
            ProjectDTO Project = GetProject();

            await client.PostAsync("api/Projects", new StringContent(JsonConvert.SerializeObject(Project), Encoding.UTF8, "application/json"));
            HttpResponseMessage responce = await client.GetAsync("api/Projects");
            ProjectDTO returnedProject = JsonConvert.DeserializeObject<List<ProjectDTO>>(await responce.Content.ReadAsStringAsync()).First(t => t.Name == Project.Name);

            Assert.NotNull(returnedProject);
            await client.DeleteAsync($"api/Projects/{returnedProject.Id}");
        }

        [Fact]
        public async Task DeleteProject_WhenIdIsNotExist_ThanNotFoundResponce()
        {
            int id = -1;

            HttpResponseMessage message = await client.DeleteAsync($"api/Projects/{id}");

            Assert.Equal(HttpStatusCode.BadRequest, message.StatusCode);
        }
        [Fact]
        public async Task UpdateProject_WhenDescrioptionIsChanged_ThanProjectHaveNewDescription()
        {
            ProjectDTO Project = GetProject();
            string newDescription = "new desctioption";

            await client.PostAsync("api/Projects", new StringContent(JsonConvert.SerializeObject(Project), Encoding.UTF8, "application/json"));
            HttpResponseMessage message = await client.GetAsync("api/Projects");
            int updatedProjectId = JsonConvert.DeserializeObject<List<ProjectDTO>>(await message.Content.ReadAsStringAsync()).FirstOrDefault(t => t.Name == Project.Name).Id;
            HttpResponseMessage update = await client.PutAsync($"api/Projects/{updatedProjectId}", new StringContent("{" + $"\"NewDescription\":\"{newDescription}\"" + "}", Encoding.UTF8, "application/json"));
            HttpResponseMessage responseMessage = await client.GetAsync($"api/Projects/{updatedProjectId}");
            ProjectDTO updatedProject = JsonConvert.DeserializeObject<ProjectDTO>(await responseMessage.Content.ReadAsStringAsync());

            Assert.Equal(newDescription, updatedProject.Description);

            await client.DeleteAsync($"api/Projects/{updatedProjectId}");
        }

        private ProjectDTO GetProject() => new ProjectDTO()
        {
            Name = "Test",
            Deadline = new System.DateTime(2021, 7, 10),
            Description = "description",
            AuthorId = 1,
            CreatedAt = new System.DateTime(2002, 4, 4),
            TeamId = 1
        };
    }
}
