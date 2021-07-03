using BSA_Task1.AdditionalClasses;
using BSA_Task1.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace BSA_Task1.Services
{
    class LINQRequestService
    {
        private static ModelService service;
        private static Collection<User> users;
        private static Collection<Project> projects;
        private static Collection<Team> teams;
        private static Collection<Task> tasks;
        public LINQRequestService()
        {
            service = new ModelService();
            users = service.GetUsersModel();
            projects = service.GetProjectsModel();
            teams = service.GetTeamsModel();
            tasks = service.GetTasksModel();
        }
        public ReadOnlyCollection<MainProjectModel> GetMainModel()
        {
            return new ReadOnlyCollection<MainProjectModel>(projects
                .Join(users, p => p.AuthorId, u => u.Id, (p, u) => new { Author = u, Project = p })
                .Join(teams, pr => pr.Project.TeamId, t => t.Id, (pr, t) => new MainProjectModel
                {
                    Project = pr.Project,
                    Author = pr.Author,
                    Task = new Collection<TaskM>(
                        pr.Project.Tasks.
                        Select(
                            task => new TaskM
                            {
                                Performer = users.Where(u => u.Id == task.PerformerId).First()
                            }).ToList()),
                    Team = t
                }).ToList());
        }
        public Dictionary<Project, int> Task1(int userId) =>
            projects.ToDictionary(pr => pr, value => value.Tasks.Count(task => task.PerformerId == userId));

        public Collection<Task> Task2(int userId) =>
            new Collection<Task>(tasks.Where(task => task.PerformerId == userId && task.Name.Length < 45).ToList());

        public Collection<(int id, string name)> Task3(int userId) =>
            new Collection<(int id, string name)>(
                tasks
                .Where(task => task.PerformerId == userId && task.FinishedAt?.Year == 2021)
                .Select(task => (task.Id, task.Name))
                .ToList()
            );

        public Collection<(int id, string name, IGrouping<int?, User> users)> Task4() =>
           new Collection<(int id, string name, IGrouping<int?, User> users)>(teams
               .Select(team => (team.Id, team.Name,
                  team.Users
               .Where(user => user.BirthDay.HasValue && DateTime.Now.Year - user.BirthDay.Value.Year > 10)
               .OrderByDescending(user => user.RegisteredAt)
               .GroupBy(user => user.TeamId).FirstOrDefault()
               )).ToList());

        public Collection<User> Task5() => new Collection<User>(
                users
            .OrderBy(u=>u.FirstName)
            .Select(u=> {
                u.Tasks = new Collection<Task>(u.Tasks
                    .OrderByDescending(task => task.Name.Length)
                    .ToList());
                return u;
            })
            .ToList()
            );

        public UserStr Task6(int userId) => users.Where(user => user.Id == userId)
                .Select(u => new UserStr
                {
                    User = u,
                    LastProject = u.Projects.OrderBy(pr => pr.CreatedAt).LastOrDefault() ?? null,
                    AmountOfTasks = u.Projects.LastOrDefault() != null ? u.Projects.OrderBy(pr => pr.CreatedAt).LastOrDefault().Tasks.Count : 0,
                    AmountCanceledTasks = u.Tasks.Count(task => !task.FinishedAt.HasValue),
                    LongestTask =  u.Tasks.Where(task => task.FinishedAt.HasValue)
                    .OrderBy(task => task.CreatedAt.Subtract(task.FinishedAt.Value)).FirstOrDefault()
                }).FirstOrDefault();

        public Collection<ProjectStr> Task7() => new Collection<ProjectStr>(projects
            .Select(obj => new ProjectStr
            {
                Project = obj,
                LongestTask = obj.Tasks.OrderBy(task => task.Description.Length).LastOrDefault(),
                ShortestTask = obj.Tasks.OrderBy(task => task.Name.Length).FirstOrDefault(),
                AmountOfUsers = (obj.Description?.Length > 20 || obj.Tasks?.Count < 3) ?
                 users.Count(user => user.TeamId == teams.Where(team => team.Id == obj.TeamId).FirstOrDefault().Id) : -1

            }).ToList());
    }
}
