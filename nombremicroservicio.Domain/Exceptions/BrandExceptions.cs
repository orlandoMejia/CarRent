using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nombremicroservicio.Domain.Exceptions
{
    public class BrandException : AppException
    {
        public BrandException() { }
        public BrandException(string message) : base(message) { }
        public BrandException(string message, System.Exception inner) : base(message, inner) { }
        protected BrandException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
