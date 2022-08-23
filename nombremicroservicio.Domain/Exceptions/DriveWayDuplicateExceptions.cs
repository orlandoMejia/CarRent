using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nombremicroservicio.Domain.Exceptions
{
    public class DriveWayDuplicateExceptions : AppException
    {
        public DriveWayDuplicateExceptions() { }
        public DriveWayDuplicateExceptions(string message) : base(message) { }

        public DriveWayDuplicateExceptions(string message, System.Exception inner) : base(message, inner) { }
        protected DriveWayDuplicateExceptions(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
