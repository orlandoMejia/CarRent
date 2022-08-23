using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nombremicroservicio.Entities
{
    public class Assigment
    {
        public Guid Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public Client Client { get; set; }
        [Required]
        public DriveWay DriveWay { get; set; }



    }
}
