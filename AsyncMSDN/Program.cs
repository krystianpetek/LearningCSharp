using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncMSDN
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            HttpClient client = new HttpClient();

            Coffee cup = PourCoffee();
            Console.WriteLine("Coffee is ready!");

            var eggsTask = FryEggAsync(2);
            var baconTask = FryBaconAsync(3);
            var toastTask = MakeToastWithButterAndJamAsync(2);
            var task = downloadURL(client, "https://google.com/");

            List<Task> listOfTasks = new List<Task>() { eggsTask, baconTask, toastTask };


            while (listOfTasks.Count > 0)
            {
                var finishedTask = await Task.WhenAny(listOfTasks);

                if (finishedTask == eggsTask)
                    Console.WriteLine("Eggs are ready!");
                else if (finishedTask == baconTask)
                    Console.WriteLine("Bacon is ready!");
                else if (finishedTask == toastTask)
                    Console.WriteLine("Toast is ready!");

                listOfTasks.Remove(finishedTask);
            }

            Juice oj = PourOJ();
            Console.WriteLine("OJ is ready!");
            Console.WriteLine("Breakfast is ready!");

            var materializedTask = await task;
            Console.WriteLine(materializedTask);

            var task2 = calculatingTask();
            var materializedTask2 = await task2;

            Console.WriteLine(materializedTask2);
        }

        private static async Task<string> calculatingTask()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            var task = Task.Run( async() =>
            {
                await Task.Delay(5000);
                Console.WriteLine("done task1");
                return "";
            });

            var task2 = Task.Run(async () =>
            {
                await Task.Delay(5000);
                Console.WriteLine("done task2");
                return "";
            });

            await Task.WhenAll(task, task2);

            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds + "ms";
        }

        private static async Task<string> downloadURL(HttpClient client, string url)
        {
            return await client.GetStringAsync(url);

        }

        private static Juice PourOJ()
        {
            Console.WriteLine("Pouring orange juice");
            return new Juice();
        }

        private static void ApplyJam(Toast toast) => Console.WriteLine("Putting jam on the toast");

        private static void ApplyButter(Toast toast) => Console.WriteLine("Putting butter on the toast");

        private static async Task<Toast> MakeToastWithButterAndJamAsync(int slices)
        {
            var toast = await ToastBreadAsync(slices);
            ApplyButter(toast);
            ApplyJam(toast);

            return toast;
        }
        private static async Task<Toast> ToastBreadAsync(int slices)
        {
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("Putting a slice of bread in the toaster");
            }

            Console.WriteLine("Start toasting...");
            await Task.Delay(3000);
            Console.WriteLine("Remove toast from toaster");

            return new Toast();
        }

        private static async Task<Bacon> FryBaconAsync(int slices)
        {
            Console.WriteLine($"putting {slices} slices of bacon in the pan");
            Console.WriteLine("cooking first side of bacon...");
            await Task.Delay(3000);
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("flipping a slice of bacon");
            }
            Console.WriteLine("cooking the second side of bacon...");
            await Task.Delay(3000);
            Console.WriteLine("Put bacon on plate");

            return new Bacon();
        }

        private static async Task<Egg> FryEggAsync(int howMany)
        {
            Console.WriteLine("Warming the egg pan...");
            await Task.Delay(3000);
            Console.WriteLine($"cracking {howMany} eggs");
            Console.WriteLine("cooking the eggs ...");
            await Task.Delay(3000);
            Console.WriteLine("Put eggs on plate");

            return new Egg();
        }

        private static Coffee PourCoffee()
        {
            Console.WriteLine("Pouring coffee");
            return new Coffee();
        }
    }
}
