using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nombremicroservicio.Repository.Executive.Queries
{
    public class ExecutiveDto
    {

        public string IdentificationNumber { get; set; }
        public string Names { get; set; }

        public string LastNames { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string Celphone { get; set; }
        public Entities.DriveWay DriveWay { get; set; }

        public ExecutiveDto()
        {
        }



    }
}
