using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatchAsyncTask
{
    public class SingleTask
    {
        public void WillThrowException()
        {
            throw new JustTestException("throw it!");
        }
    }
}
