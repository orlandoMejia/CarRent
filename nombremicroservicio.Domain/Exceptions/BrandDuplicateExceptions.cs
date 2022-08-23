using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nombremicroservicio.Domain.Exceptions
{
    public class BrandDuplicateExceptions : AppException
    {
        public BrandDuplicateExceptions() { }
        public BrandDuplicateExceptions(string message) : base(message) { }

        public BrandDuplicateExceptions(string message, System.Exception inner) : base(message, inner) { }
        protected BrandDuplicateExceptions(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
