
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace BSA_Task1.Services
{
    public class TaskStateService : IDisposable
    {
        readonly LINQRequestService _service;
        readonly HttpService _httpService;
        public TaskStateService(LINQRequestService service) {
            _service = service;
            _httpService = new HttpService();
        }

        System.Timers.Timer timer;
        public void StartTimer(int deley)
        {
            if(!_service._isFinishInitialing)
            {
                Console.WriteLine("Initial is not finished, wait");
                Thread.Sleep(2000);
                StartTimer(deley);
                return;
            }
            timer = new System.Timers.Timer(deley);
            timer.Elapsed += async (s, e) => {
                Console.WriteLine("the id of changed task is " + await MarkRandomTaskWithDelay(deley));
            };
            timer.Start();
        }

        public async Task<int> MarkRandomTaskWithDelay(int deley)
        {
            await Task.Delay(deley);
            Random random = new Random();
            int id = _service.tasks[random.Next(0, _service.tasks.Count)].Id;
            TaskCompletionSource<int> source = new TaskCompletionSource<int>();
            var rez = await _httpService.UpdateTaskState(id);
            if (rez.StatusCode == System.Net.HttpStatusCode.NotFound)
                source.SetException(new InvalidOperationException($"Something went wrong:{rez.StatusCode}"));
            else
                source.SetResult(id);

            int rezId = await source.Task;
            return rezId;
        }

        public void Dispose()
        {
            timer?.Dispose();
            _httpService?.Dispose();
        }
    }
}
