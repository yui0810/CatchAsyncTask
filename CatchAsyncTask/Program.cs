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
                SingleTask singleTask = new SingleTask();
                // Start the task.
                var task = Task.Factory.StartNew(() => { singleTask.WillThrowException(); });

                // Wait the task.
                task.Wait();
            }
            catch (AggregateException ex)
            {
                Console.WriteLine(ex.InnerException.Message);
            }

            Console.ReadKey();
        }
    }
}
