using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nombremicroservicio.Domain.Exceptions
{
    public class CreditRequestDateException : AppException
    {
        public CreditRequestDateException() { }
        public CreditRequestDateException(string message) : base(message) { }

        public CreditRequestDateException(string message, System.Exception inner) : base(message, inner) { }
        protected CreditRequestDateException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
