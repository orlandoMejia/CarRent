using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nombremicroservicio.Domain.Exceptions
{
    public class ExecutiveException : AppException
    {
        public ExecutiveException() { }
        public ExecutiveException(string message) : base(message) { }

        public ExecutiveException(string message, System.Exception inner) : base(message, inner) { }
        protected ExecutiveException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
