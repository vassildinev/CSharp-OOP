using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RangeExceptions
{
    class InvalidRangeException<T> : ApplicationException
    {
        public InvalidRangeException(string msg)
            :base(msg)
        {
        }
    }
}
