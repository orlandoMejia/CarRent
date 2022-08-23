using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nombremicroservicio.Domain.Exceptions
{
    public class CreditRequestException : AppException
    {
        public CreditRequestException() { }
        public CreditRequestException(string message) : base(message) { }

        public CreditRequestException(string message, System.Exception inner) : base(message, inner) { }
        protected CreditRequestException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
