using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatchAsyncTask
{
    public class JustTestException : Exception
    {
        public JustTestException(string message) : base(message) { }
    }
}
