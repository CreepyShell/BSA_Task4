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
    public class TaskControllerIntegrationTests:BaseIntegrationTest
    {
        
        public TaskControllerIntegrationTests() : base()
        {
           
        }

        [Fact]
        public async Task GetTaskById_WhenIdIsNotExist_ThenNotFoundResponce()
        {
            int id = -1;

            HttpResponseMessage response = await client.GetAsync($"api/tasks/{id}");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
        [Fact]
        public async Task CreateTask_WhenAllRight_ThanCreateProjectInDb()
        {
            TaskDTO task = GetTask();

            await client.PostAsync("api/tasks", new StringContent(JsonConvert.SerializeObject(task), Encoding.UTF8, "application/json"));
            HttpResponseMessage responce = await client.GetAsync("api/tasks");
            TaskDTO returnedTask = JsonConvert.DeserializeObject<List<TaskDTO>>(await responce.Content.ReadAsStringAsync()).First(t => t.Name == task.Name);

            Assert.NotNull(returnedTask);
            await client.DeleteAsync($"api/tasks/{returnedTask.Id}");
        }

        [Fact]
        public async Task DeleteTask_WhenIdIsNotExist_ThanNotFoundResponce()
        {
            int id = -1;

            HttpResponseMessage message = await client.DeleteAsync($"api/tasks/{id}");

            Assert.Equal(HttpStatusCode.BadRequest, message.StatusCode);
        }
        [Fact]
        public async Task UpdateTask_WhenPerfomerIdAndDescriptionIsChanged_ThanTaskHaveNewPerfomerIdAndDescription()
        {
            TaskDTO task = GetTask();
            int newPerfomer = 2;
            string newDescription = "new description";

            await client.PostAsync("api/tasks", new StringContent(JsonConvert.SerializeObject(task), Encoding.UTF8, "application/json"));
            HttpResponseMessage message = await client.GetAsync("api/tasks");
            int updatedTaskId = JsonConvert.DeserializeObject<List<TaskDTO>>(await message.Content.ReadAsStringAsync()).FirstOrDefault(t => t.Name == task.Name).Id;
            HttpResponseMessage update = await client.PutAsync($"api/tasks/{updatedTaskId}", 
                new StringContent("{" + $"\"NewPerformerId\":{newPerfomer}, \"NewDescription\":\"{newDescription}\"" + "}", Encoding.UTF8, "application/json"));
            HttpResponseMessage responseMessage = await client.GetAsync($"api/tasks/{updatedTaskId}");
            TaskDTO updatedTask = JsonConvert.DeserializeObject<TaskDTO>(await responseMessage.Content.ReadAsStringAsync());

            Assert.Equal(newPerfomer, updatedTask.PerformerId);
            Assert.Equal(newDescription, updatedTask.Description);
            await client.DeleteAsync($"api/tasks/{updatedTaskId}");
        }

        [Fact]
        public async Task GetExecutedTask_When3DoneAnd2Not_ThenReturn3DoneTasks()
        {
            List<TaskDTO> tasks = new List<TaskDTO>();
            for (int i = 0; i < 5; i++)
            {
                tasks.Add(GetTask());
                tasks[i].FinishedAt = i % 2 == 0 ? new System.DateTime(2020, i + 1, i + 3) : null;
                await client.PostAsync("api/tasks", new StringContent(JsonConvert.SerializeObject(tasks[i]), Encoding.UTF8, "application/json"));
            }

            HttpResponseMessage responceAllTasks = await client.GetAsync("api/tasks");
            List<TaskDTO> allTasks = JsonConvert.DeserializeObject<List<TaskDTO>>(await responceAllTasks.Content.ReadAsStringAsync()).Where(t => t.Name == tasks[0].Name).ToList();
            HttpResponseMessage responce = await client.GetAsync("api/tasks/unexecuted/1");
            List<TaskDTO> unExecutedTask = JsonConvert.DeserializeObject<List<TaskDTO>>(await responce.Content.ReadAsStringAsync());

            Assert.Equal(2, unExecutedTask.Count);
            Assert.Equal(3, allTasks.Count - unExecutedTask.Count);

            for (int i = 0; i < 5; i++)
                await client.DeleteAsync($"api/tasks/{allTasks[i].Id}");
        }
        [Fact]
        public async Task GetExecutedTask_WhenIdIsNotExist_ThenStstusCodeNotFound()
        {
            int userId = -1;

            HttpResponseMessage responce = await client.GetAsync($"api/tasks/unexecuted/{userId}");

            Assert.Equal(HttpStatusCode.NotFound, responce.StatusCode);
        }

        [Fact]
        public async Task GetExecutedTask_WhenItIsNotUnexecutedTasks_ThenReturnEmptyList()
        {
            List<TaskDTO> tasks = new List<TaskDTO>() { GetTask(), GetTask() };
            await client.PostAsync("api/tasks", new StringContent(JsonConvert.SerializeObject(tasks[0]), Encoding.UTF8,"application/json"));
            await client.PostAsync("api/tasks", new StringContent(JsonConvert.SerializeObject(tasks[1]), Encoding.UTF8, "application/json"));

            HttpResponseMessage allResponceTasks = await client.GetAsync("api/tasks");
            List<TaskDTO> allTasks = JsonConvert.DeserializeObject<List<TaskDTO>>(await allResponceTasks.Content.ReadAsStringAsync()).Where(task => task.Name == tasks[0].Name).ToList();
            HttpResponseMessage unexcuetedResponceTasks = await client.GetAsync("api/tasks/unexecuted/1");
            List<TaskDTO> unexcuetedTasks = JsonConvert.DeserializeObject<List<TaskDTO>>(await unexcuetedResponceTasks.Content.ReadAsStringAsync());

            Assert.Empty(unexcuetedTasks);
            Assert.Equal(2, allTasks.Count);

            for (int i = 0; i < 2; i++)
                await client.DeleteAsync($"api/tasks/{allTasks[i].Id}");

        }

        private TaskDTO GetTask() => new TaskDTO()
        {
            Name = "Test",
            FinishedAt = System.DateTime.Now.AddDays(70),
            CreatedAt = System.DateTime.Now,
            Description = "descr",
            PerformerId = 1,
            ProjectId = 1,
            State = 1
        };
    }
}
