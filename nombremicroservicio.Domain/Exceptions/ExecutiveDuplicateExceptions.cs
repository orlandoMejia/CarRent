using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nombremicroservicio.Domain.Exceptions
{
    public class ExecutiveDuplicateExceptions : AppException
    {
        public ExecutiveDuplicateExceptions() { }
        public ExecutiveDuplicateExceptions(string message) : base(message) { }

        public ExecutiveDuplicateExceptions(string message, System.Exception inner) : base(message, inner) { }
        protected ExecutiveDuplicateExceptions(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
