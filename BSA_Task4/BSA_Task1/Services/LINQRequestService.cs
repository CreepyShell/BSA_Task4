using BSA_Task1.AdditionalClasses;
using BSA_Task1.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace BSA_Task1.Services
{
    public class LINQRequestService
    {
        private static ModelService service;
        public Collection<User> users;
        public Collection<Project> projects;
        public Collection<Team> teams;
        public Collection<Task> tasks;
        public bool _isFinishInitialing;
        public LINQRequestService()
        {
            service = new ModelService(async (t) =>
            {
                System.Threading.Tasks.Task init = Initialize();
                await init;
                _isFinishInitialing = init.IsCompleted;
            });
        }

        private async System.Threading.Tasks.Task Initialize()
        {
            tasks = service.GetTasksModel();
            users = await service.GetUsersModel();
            projects = await service.GetProjectsModel();
            teams = await service.GetTeamsModel();
        }
        public async System.Threading.Tasks.Task<ReadOnlyCollection<MainProjectModel>> GetMainModel()
        {
            if (!_isFinishInitialing)
                throw new InvalidOperationException("Initialization is not finished, try again");
            ReadOnlyCollection<MainProjectModel> collenction = null;
            await System.Threading.Tasks.Task.Run(() =>
            {
                collenction = new ReadOnlyCollection<MainProjectModel>(projects
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
            });
            return collenction;
        }
        public async System.Threading.Tasks.Task<Dictionary<Project, int>> Task1(int userId)
        {
            if (!_isFinishInitialing)
                throw new InvalidOperationException("Initialization is not finished, try again");
            Dictionary<Project, int> rezult = null;
            await System.Threading.Tasks.Task.Run(() =>
            {
                rezult = projects.ToDictionary(pr => pr, value => value.Tasks.Count(task => task.PerformerId == userId));
            });
            return rezult;
        }

        public async System.Threading.Tasks.Task<Collection<Task>> Task2(int userId)
        {
            if (!_isFinishInitialing)
                throw new InvalidOperationException("Initialization is not finished, try again");
            Collection<Task> rezult = null;
            await System.Threading.Tasks.Task.Run(() =>
            {
                rezult = new Collection<Task>(tasks.Where(task => task.PerformerId == userId && task.Name.Length < 45).ToList());
            });
            return rezult;
        }

        public async System.Threading.Tasks.Task<Collection<(int id, string name)>> Task3(int userId)
        {
            if (!_isFinishInitialing)
                throw new InvalidOperationException("Initialization is not finished, try again");
            Collection<(int id, string name)> rezult = null;
            await System.Threading.Tasks.Task.Run(() =>
            {
                rezult = new Collection<(int id, string name)>(
                 tasks
                 .Where(task => task.PerformerId == userId && task.FinishedAt?.Year == 2021)
                 .Select(task => (task.Id, task.Name))
                 .ToList()
             );
            });
            return rezult;
        }

        public async System.Threading.Tasks.Task<Collection<(int id, string name, IGrouping<int?, User> users)>> Task4()
        {
            if (!_isFinishInitialing)
                throw new InvalidOperationException("Initialization is not finished, try again");
            Collection<(int id, string name, IGrouping<int?, User> users)> rez = null;
            await System.Threading.Tasks.Task.Run(() =>
            {
                rez = new Collection<(int id, string name, IGrouping<int?, User> users)>(teams
                 .Select(team => (team.Id, team.Name,
                    team.Users
                 .Where(user => user.BirthDay.HasValue && DateTime.Now.Year - user.BirthDay.Value.Year > 10)
                 .OrderByDescending(user => user.RegisteredAt)
                 .GroupBy(user => user.TeamId).FirstOrDefault()
                 )).ToList());
            });
            return rez;
        }

        public async System.Threading.Tasks.Task<Collection<User>> Task5()
        {
            if (!_isFinishInitialing)
                throw new InvalidOperationException("Initialization is not finished, try again");

            Collection<User> rez = null;
            await System.Threading.Tasks.Task.Run(() =>
            {
                rez = new Collection<User>(
                users.OrderBy(u => u.FirstName).Select(u =>
                {
                    u.Tasks = new Collection<Task>(u.Tasks
                        .OrderByDescending(task => task.Name.Length)
                        .ToList());
                    return u;
                }).ToList());
            });
            return rez;
        }

        public async System.Threading.Tasks.Task<UserStr> Task6(int userId)
        {
            if (!_isFinishInitialing)
                throw new InvalidOperationException("Initialization is not finished, try again");

            UserStr userStr = null;
            await System.Threading.Tasks.Task.Run(() =>
            {
                userStr = users.Where(user => user.Id == userId)
                 .Select(u => new UserStr
                 {
                     User = u,
                     LastProject = u.Projects.OrderBy(pr => pr.CreatedAt).LastOrDefault() ?? null,
                     AmountOfTasks = u.Projects.LastOrDefault() != null ? u.Projects.OrderBy(pr => pr.CreatedAt).LastOrDefault().Tasks.Count : 0,
                     AmountCanceledTasks = u.Tasks.Count(task => !task.FinishedAt.HasValue),
                     LongestTask = u.Tasks.Where(task => task.FinishedAt.HasValue)
                     .OrderBy(task => task.CreatedAt.Subtract(task.FinishedAt.Value)).FirstOrDefault()
                 }).FirstOrDefault();
            });
            return userStr;
        }

        public async System.Threading.Tasks.Task<Collection<ProjectStr>> Task7()
        {
            if (!_isFinishInitialing)
                throw new InvalidOperationException("Initialization is not finished, try again");
            Collection<ProjectStr> rez = null;

            await System.Threading.Tasks.Task.Run(() =>
            {
                rez = new Collection<ProjectStr>(projects.Select(obj => new ProjectStr
                {
                    Project = obj,
                    LongestTask = obj.Tasks.OrderBy(task => task.Description.Length).LastOrDefault(),
                    ShortestTask = obj.Tasks.OrderBy(task => task.Name.Length).FirstOrDefault(),
                    AmountOfUsers = (obj.Description?.Length > 20 || obj.Tasks?.Count < 3) ?
                        users.Count(user => user.TeamId == teams.Where(team => team.Id == obj.TeamId).FirstOrDefault().Id) : -1

                }).ToList());
            });
            return rez;
        }
    }
}
