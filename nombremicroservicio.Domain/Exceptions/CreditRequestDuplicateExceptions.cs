using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nombremicroservicio.Domain.Exceptions
{
    public class CreditRequestDuplicateExceptions : AppException
    {
        public CreditRequestDuplicateExceptions() { }
        public CreditRequestDuplicateExceptions(string message) : base(message) { }

        public CreditRequestDuplicateExceptions(string message, System.Exception inner) : base(message, inner) { }
        protected CreditRequestDuplicateExceptions(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
