using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatchAsyncTask
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                MethodCall().Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("in Main, {0}", ex.InnerException.Message));
            }

            Console.ReadKey();
        }

        private static async Task MethodCall()
        {
            SingleTask singleTask = new SingleTask();

            try
            {
                Task[] tasks = new Task[2];
                for (int i = 0; i < 2; i++)
                {

                    var newTask = singleTask.WillThrowException()
                        .ContinueWith(task =>
                        {
                            if (task.IsFaulted)
                            {
                                var flattened = task.Exception.Flatten();

                                // Catch exception
                                flattened.Handle(ex => { Console.WriteLine("task Error:" + ex.Message); return true; });
                            }
                        });

                    tasks[i] = newTask;
                }

                await Task.WhenAll(tasks);
            }
            catch (AggregateException ex)
            {
                Console.WriteLine(string.Format("in Method, {0}", ex.InnerException.Message));
            }
        }
    }
}
