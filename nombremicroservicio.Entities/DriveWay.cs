using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nombremicroservicio.Entities
{
    public class DriveWay
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Required]
        [StringLength(255)]
        public string Address { get; set; }
        [Required]
        [StringLength(255)]
        public string Phone { get; set; }
        [Required]
        [StringLength(255)]
        public string Number { get; set; }



    }
}
