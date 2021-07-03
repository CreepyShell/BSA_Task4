using BSA_Task1.Models;
using System.Collections.ObjectModel;
using System.Linq;
using Newtonsoft.Json;

namespace BSA_Task1.Services
{
    public class ModelService
    {
        private Collection<Project> projects;
        private Collection<Task> tasks;
        private Collection<User> users;
        private Collection<Team> teams;

        private HttpService httpService;
       public ModelService()
       {
            httpService = new HttpService();
            projects = JsonConvert.DeserializeObject<Collection<Project>>(httpService.GetProjects().Content.ReadAsStringAsync().Result);
            tasks = JsonConvert.DeserializeObject<Collection<Task>>(httpService.GetTasks().Content.ReadAsStringAsync().Result);
            users = JsonConvert.DeserializeObject<Collection<User>>(httpService.GetUsers().Content.ReadAsStringAsync().Result);
            teams = JsonConvert.DeserializeObject<Collection<Team>>(httpService.GetTeams().Content.ReadAsStringAsync().Result);
       }

        public Collection<Project> GetProjectsModel()
        {
            foreach (var item in projects)
            {
                item.Tasks = new Collection<Task>(tasks.Where(task => task.ProjectId == item.Id).ToList());
            }
            return projects;
        }

        public Collection<Task> GetTasksModel() => tasks;
        public Collection<User> GetUsersModel()
        {
            foreach (var item in users)
            {
                item.Tasks = new Collection<Task>(tasks.Where(task => task.PerformerId == item.Id).ToList());
                item.Projects = new Collection<Project>(projects.Where(project => project.AuthorId == item.Id).ToList());
            }
            return users;
        }
        public Collection<Team> GetTeamsModel()
        {
            foreach (var item in teams)
            {
                item.Users = new Collection<User>(users.Where(user => user.TeamId == item.Id).ToList());
                item.Projects = new Collection<Project>(projects.Where(project => project.TeamId == item.Id).ToList());
            }
            return teams;
        }

    }
}
