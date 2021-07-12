using BSA_Task1.Services;
using System;
using System.Threading.Tasks;

namespace BSA_Task1
{
    class Program
    {
        private static LINQRequestService service;
        static void Main(string[] args)
        {
            service = new LINQRequestService();
            TaskStateService stateService = new TaskStateService(service);
                stateService.StartTimer(1000);


            Task t = new Task(()=> MainWork());
            t.RunSynchronously();

            Console.ReadLine();
            Console.WriteLine("That`s all! Thank you for attention!");
        }


        private static async Task MainWork()
        {
            Console.WriteLine("Press any button to start");
            Console.ReadLine();
            Console.WriteLine("Main model:");
            foreach (var project in await service.GetMainModel())
                Console.WriteLine(project.Project.Id + "--" + project.Author.Id + "--" + project.Task.Count + "--" + project.Team.Name);
            Console.WriteLine("Press any button to continue\n");

            Console.WriteLine("Task№1");
            foreach (var item in await service.Task1(1))
                Console.WriteLine(item.Key.Id + "--" + item.Value);
            Console.WriteLine("Press any button to continue\n");

            Console.WriteLine("Task№2");
            foreach (var item in await service.Task2(1))
                Console.WriteLine(item.Id + "--" + item.Name.Length);
            Console.WriteLine("Press any button to continue\n");

            Console.WriteLine("Task№3");
            foreach (var item in await service.Task3(1))
                Console.WriteLine(item.id + "--" + item.name);
            Console.WriteLine("Press any button to continue\n");
            
            //тоже как и 7 задание :)
            //Console.WriteLine("Task№4");
            //foreach (var item in await service.Task4())
            //{
            //    Console.WriteLine(item.id + "--" + item.users.Count() + "--" + item.users.Key);
            //    foreach (var item2 in item.users)
            //        Console.WriteLine(item2.BirthDay?.Year + "--" + item2.RegisteredAt);
            //}
            //Console.WriteLine("Press any button to continue\n");
            //Console.ReadLine();

            Console.WriteLine("Task№5");
            foreach (var item in await service.Task5())
            {
                Console.WriteLine(item.Id + "--" + item.FirstName);
                foreach (var item2 in item.Tasks)
                    Console.WriteLine(item2.Id + "--" + item2.Name.Length);
            }
            Console.WriteLine("Press any button to continue\n");

            Console.WriteLine("Task№6");
            var rez = await service.Task6(1);
            Console.WriteLine(rez?.User.Id + "--" + rez?.LastProject.CreatedAt + "--"
                + rez?.AmountOfTasks + "--"
                + rez?.AmountCanceledTasks);
            Console.WriteLine("Press any button to continue\n");

            //это задание работать не будет потому что я поленился добавить в бд кое-какие столбцы(будет просто вылетать null exception)
            //Console.WriteLine("Task№7");
            //foreach (var item in await service.Task7())
            //{
            //    Console.WriteLine(item.Project?.Id + "--" + item.LongestTask?.Description.Length + "--" + item.ShortestTask?.Name.Length + "--" + item.AmountOfUsers);
            //}
            //Console.WriteLine("Press any button to continue\n");
        }
    }
}
