using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nombremicroservicio.Domain.Exceptions
{
    public class ClientDuplicateExceptions : AppException
    {
        public ClientDuplicateExceptions() { }
        public ClientDuplicateExceptions(string message) : base(message) { }

        public ClientDuplicateExceptions(string message, System.Exception inner) : base(message, inner) { }
        protected ClientDuplicateExceptions(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
