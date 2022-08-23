using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nombremicroservicio.Domain.Exceptions
{
    public class DriveWayException : AppException
    {
        public DriveWayException() { }
        public DriveWayException(string message) : base(message) { }

        public DriveWayException(string message, System.Exception inner) : base(message, inner) { }
        protected DriveWayException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
