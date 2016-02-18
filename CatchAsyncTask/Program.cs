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

        static async Task MethodCall()
        {

            SingleTask singleTask = new SingleTask();

            // Start the task.
            var task = singleTask.WillThrowException();

            try
            {
                // if task.Wait(), will catch in method
                // if await task, will catch in main
                task.Wait();
            }
            catch (AggregateException ex)
            {
                Console.WriteLine(string.Format("in Method, {0}", ex.InnerException.Message));
            }

            Console.WriteLine("Task IsCanceled: " + task.IsCanceled);
            Console.WriteLine("Task IsFaulted:  " + task.IsFaulted);
            if (task.Exception != null)
            {
                Console.WriteLine("Task Exception Message: "
                    + task.Exception.Message);
                Console.WriteLine("Task Inner Exception Message: "
                    + task.Exception.InnerException.Message);
            }
        }
    }
}
