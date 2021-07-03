using System.Net.Http;

namespace BSA_Task1.Services
{
    public class HttpService
    {
        private HttpClient client = new HttpClient();

        public HttpResponseMessage GetProjects() =>
            client.GetAsync("https://localhost:5001/api/Projects")
            .Result;

        public HttpResponseMessage GetTasks() =>
            client.GetAsync("https://localhost:5001/api/Tasks")
            .Result;

        public HttpResponseMessage GetTeams() =>
            client.GetAsync("https://localhost:5001/api/Teams")
            .Result;

        public HttpResponseMessage GetUsers() =>
            client.GetAsync("https://localhost:5001/api/Users")
            .Result;
    }
}
