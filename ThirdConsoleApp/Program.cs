using System;
using System.Threading.Tasks;

class Program
{
    static async Task RunTasksAll()
    {
        Random rnd = new Random();
        Task t1 = Task.Run(async () => { await Task.Delay(rnd.Next(1000, 3000)); Console.WriteLine("Task 1"); });
        Task t2 = Task.Run(async () => { await Task.Delay(rnd.Next(1000, 3000)); Console.WriteLine("Task 2"); });
        Task t3 = Task.Run(async () => { await Task.Delay(rnd.Next(1000, 3000)); Console.WriteLine("Task 3"); });

        await Task.WhenAll(t1, t2, t3);
    }

    static async Task RunTasksFirstCompleted()
    {
        Random rnd = new Random();
        Task<string> t1 = Task.Run(async () => { await Task.Delay(rnd.Next(1000, 3000)); return "Task 1"; });
        Task<string> t2 = Task.Run(async () => { await Task.Delay(rnd.Next(1000, 3000)); return "Task 2"; });
        Task<string> t3 = Task.Run(async () => { await Task.Delay(rnd.Next(1000, 3000)); return "Task 3"; });

        Task<string> firstCompleted = await Task.WhenAny(t1, t2, t3);
        Console.WriteLine("First completed: " + firstCompleted.Result);
    }

    static async Task Main()
    {
        Console.WriteLine("=== First Task Group ===");
        await RunTasksAll();
        Console.WriteLine("All tasks completed!");

        Console.WriteLine("\n=== Second Task Group ===");
        await RunTasksFirstCompleted();
    }
}
