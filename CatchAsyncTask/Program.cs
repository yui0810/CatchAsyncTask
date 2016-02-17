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
            catch(Exception ex)
            {
                Console.WriteLine(string.Format("in Main, {0}", ex.InnerException.Message));
            }

            Console.ReadKey();
        }

        static async Task MethodCall()
        {
            try
            {
                SingleTask singleTask = new SingleTask();
                // Start the task.
                var task = Task.Factory.StartNew(() => { singleTask.WillThrowException(); });

                // if task.Wait(), will catch in method
                // if await task, will catch in main
                await task;
            }
            catch (AggregateException ex)
            {
                Console.WriteLine(string.Format("in Method, {0}", ex.InnerException.Message));
            }
        }
    }
}
