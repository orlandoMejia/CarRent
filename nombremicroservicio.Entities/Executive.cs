using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nombremicroservicio.Entities
{
    public class Executive
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(255)]

        public string IdentificationNumber { get; set; }
        [Required]
        [StringLength(255)]
        public string Names { get; set; }
        [Required]
        [StringLength(255)]

        public string LastNames { get; set; }
        [Required]
        [StringLength(255)]

        public string Address { get; set; }
        [Required]
        [StringLength(255)]

        public string Phone { get; set; }
        [Required]
        [StringLength(255)]

        public string Celphone { get; set; }
        public DriveWay DriveWay { get; set; }
        [Required]
        [StringLength(255)]

        public string Age { get; set; }
    }
}
