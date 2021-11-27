using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson14
{
    public class OperationRestrictedException : Exception
    {
        public string OperationName { get; set; }

        public OperationRestrictedException(string message) : base(message)
        {

        }

        public OperationRestrictedException(string message, Exception innerException) : base(message, innerException)
        {

        }

        public OperationRestrictedException(string message, Exception innerException, string operation) : this(message, innerException)
        {
            OperationName = operation;
        }
    }
}
