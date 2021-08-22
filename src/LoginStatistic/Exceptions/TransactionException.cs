using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginStatistic.Exceptions
{
    public class TransactionException: Exception
    {
        public TransactionException()
        { }

        public TransactionException(string message)
            : base(message)
        { }

        public TransactionException(string message, Exception inner)
            : base(message, inner)
        { }
    }
}
