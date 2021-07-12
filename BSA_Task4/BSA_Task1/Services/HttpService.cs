using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BSA_Task1.Services
{
    public class HttpService : IDisposable
    {
        private HttpClient client = new HttpClient();

        public void Dispose()
        {
            client?.Dispose();
        }

        public async Task<HttpResponseMessage> GetProjects() =>
            await client.GetAsync("https://localhost:5001/api/Projects");

        public async Task<HttpResponseMessage> GetTasks() =>
            await client.GetAsync("https://localhost:5001/api/Tasks");

        public async Task<HttpResponseMessage> GetTeams() =>
            await client.GetAsync("https://localhost:5001/api/Teams");

        public async Task<HttpResponseMessage> UpdateTaskState(int id) =>
            await client.PutAsync($"https://localhost:5001/api/Tasks/{id}", new StringContent("{" + $"\"NewState\":{3}" + "}", Encoding.UTF8, "application/json"));

        public async Task<HttpResponseMessage> GetUsers() =>
            await client.GetAsync("https://localhost:5001/api/Users");
    }
}
