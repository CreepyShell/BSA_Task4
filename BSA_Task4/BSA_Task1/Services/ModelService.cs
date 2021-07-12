using BSA_Task1.Models;
using System.Collections.ObjectModel;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System;

namespace BSA_Task1.Services
{
    public class ModelService
    {
        private Collection<Project> projects;
        private Collection<Models.Task> tasks;
        private Collection<User> users;
        private Collection<Team> teams;
        public System.Threading.Tasks.Task AllTasks { get; set; }
        private HttpService httpService;
        public ModelService(Action<System.Threading.Tasks.Task> continueInitialize)
        {
            httpService = new HttpService();
            System.Threading.Tasks.Task.Run(() => Initialize())
                .ContinueWith(continueInitialize);
        }
        private async Task<string> ReadProjectStringAsync() =>await (await httpService.GetProjects()).Content.ReadAsStringAsync();
        private async Task<string> ReadTaskStringAsync() => await (await httpService.GetTasks()).Content.ReadAsStringAsync();
        private async Task<string> ReadTeamStringAsync() => await (await httpService.GetTeams()).Content.ReadAsStringAsync();
        private async Task<string> ReadUserStringAsync() => await (await httpService.GetUsers()).Content.ReadAsStringAsync();
        private async System.Threading.Tasks.Task Initialize()
        {
            System.Console.WriteLine("Start initialize");
            Task<string> projectTask = ReadProjectStringAsync();
            Task<string> taskTask = ReadTaskStringAsync();
            Task<string> userTask = ReadUserStringAsync();
            Task<string> teamTask = ReadTeamStringAsync();

            await System.Threading.Tasks.Task.WhenAll(new System.Threading.Tasks.Task[] { projectTask, taskTask, userTask, teamTask });
            Console.WriteLine("project");
            projects = JsonConvert.DeserializeObject<Collection<Project>>(await projectTask);
            Console.WriteLine($"finish project:{projects.Count}");
            Console.WriteLine("task");
            tasks = JsonConvert.DeserializeObject<Collection<Models.Task>>(await taskTask);
            Console.WriteLine($"finish tasks:{tasks.Count}");
            Console.WriteLine("team");
            teams = JsonConvert.DeserializeObject<Collection<Team>>(await teamTask);
            Console.WriteLine($"finish teams:{teams.Count}");
            Console.WriteLine("user");
            users = JsonConvert.DeserializeObject<Collection<User>>(await userTask);
            Console.WriteLine($"finish users:{users.Count}");

            Console.WriteLine("finish initialize");
        }

        public async Task<Collection<Project>> GetProjectsModel()
        {
            await System.Threading.Tasks.Task.Run(() =>
            {
                foreach (var item in projects)
                {
                    item.Tasks = new Collection<Models.Task>(tasks.Where(task => task.ProjectId == item.Id).ToList());
                }
            });
            return projects;
        }

        public Collection<Models.Task> GetTasksModel() => tasks;
        public async Task<Collection<User>> GetUsersModel()
        {
            await System.Threading.Tasks.Task.Run(() =>
            {
                foreach (var item in users)
                {
                    item.Tasks = new Collection<Models.Task>(tasks.Where(task => task.PerformerId == item.Id).ToList());
                    item.Projects = new Collection<Project>(projects.Where(project => project.AuthorId == item.Id).ToList());
                }
            });
            return users;
        }
        public async Task<Collection<Team>> GetTeamsModel()
        {
            await System.Threading.Tasks.Task.Run(() =>
            {
                foreach (var item in teams)
                {
                    item.Users = new Collection<User>(users.Where(user => user.TeamId == item.Id).ToList());
                    item.Projects = new Collection<Project>(projects.Where(project => project.TeamId == item.Id).ToList());
                }
            });
            return teams;
        }

    }
}
