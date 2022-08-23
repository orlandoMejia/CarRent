using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nombremicroservicio.Domain.Exceptions
{
    public class AssigmentException : AppException
    {
        public AssigmentException() { }
        public AssigmentException(string message) : base(message) { }

        public AssigmentException(string message, System.Exception inner) : base(message, inner) { }
        protected AssigmentException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
