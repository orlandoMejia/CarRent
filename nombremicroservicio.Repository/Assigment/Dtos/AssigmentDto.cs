using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nombremicroservicio.Repository.Assigment.Queries
{
    public class AssigmentDto
    {

        public DateTime Date { get; set; }
        
        public Entities.Client Client { get; set; }
        
        public Entities.DriveWay DriveWay { get; set; }
        public AssigmentDto()
        {
        }



    }
}
