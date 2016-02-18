using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatchAsyncTask
{
    public class SingleTask
    {
        public async Task WillThrowException()
        {
            await Task.Delay(100);

            throw new JustTestException("throw it!");
        }

        public async Task NotThrowException()
        {
            await Task.Delay(100);
        }
    }
}
