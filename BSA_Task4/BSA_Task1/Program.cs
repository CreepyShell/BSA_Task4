using BSA_Task1.Services;
using System;
using System.Linq;

namespace BSA_Task1
{
    class Program
    {
        private static LINQRequestService service;
        static void Main(string[] args)
        {
            service = new LINQRequestService();


            Console.WriteLine("Main model:");
            foreach (var project in service.GetMainModel())//
                Console.WriteLine(project.Project.Id + "--" + project.Author.Id + "--" + project.Task.Count + "--" + project.Team.Name);
            Console.WriteLine("Press any button to continue\n");
            Console.ReadLine();

            Console.WriteLine("Task№1");
            foreach (var item in service.Task1(43))
                Console.WriteLine(item.Key.Id + "--" + item.Value);
            Console.WriteLine("Press any button to continue\n");
            Console.ReadLine();

            Console.WriteLine("Task№2");
            foreach (var item in service.Task2(108))
                Console.WriteLine(item.Id + "--" + item.Name.Length);
            Console.WriteLine("Press any button to continue\n");
            Console.ReadLine();

            Console.WriteLine("Task№3");
            foreach (var item in service.Task3(114))
                Console.WriteLine(item.id + "--" + item.name);
            Console.WriteLine("Press any button to continue\n");
            Console.ReadLine();

            Console.WriteLine("Task№4");
            foreach (var item in service.Task4())
            {
                Console.WriteLine(item.id + "--" + item.users.Count() + "--" + item.users.Key);
                foreach (var item2 in item.users)
                    Console.WriteLine(item2.BirthDay?.Year + "--" + item2.RegisteredAt);
            }
            Console.WriteLine("Press any button to continue\n");
            Console.ReadLine();

            Console.WriteLine("Task№5");
            foreach (var item in service.Task5())
            {
                Console.WriteLine(item.Id + "--" + item.FirstName);
                foreach (var item2 in item.Tasks)
                    Console.WriteLine(item2.Id + "--" + item2.Name.Length);
            }
            Console.WriteLine("Press any button to continue\n");
            Console.ReadLine();

            Console.WriteLine("Task№6");
            var rez = service.Task6(108);
            Console.WriteLine(rez.User.Id + "--" + rez.LastProject.CreatedAt + "--"
                + rez.LongestTask.CreatedAt.Subtract(rez.LongestTask.FinishedAt.Value).TotalSeconds / 60 / 60 / 24 + "--"
                + rez.AmountOfTasks + "--"
                + rez.AmountCanceledTasks);
            Console.WriteLine("Press any button to continue\n");
            Console.ReadLine();

            Console.WriteLine("Task№7");
            foreach (var item in service.Task7())
            {
                Console.WriteLine(item.Project?.Id + "--" + item.LongestTask?.Description.Length + "--" + item.ShortestTask?.Name.Length + "--" + item.AmountOfUsers);
            }
            Console.WriteLine("Press any button to continue\n");
            Console.ReadLine();

            Console.WriteLine("That`s all! Thank you for attention!");
        }
    }
}
