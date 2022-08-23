using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nombremicroservicio.Domain.Exceptions
{
    public class ClientException : AppException
    {
        public ClientException() { }
        public ClientException(string message) : base(message) { }

        public ClientException(string message, System.Exception inner) : base(message, inner) { }
        protected ClientException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
