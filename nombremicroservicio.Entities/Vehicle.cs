using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nombremicroservicio.Entities
{
    public class Vehicle
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Plate { get; set; }
        [Required]
        [StringLength(255)]
        public string Model { get; set; }
        [Required]
        [StringLength(255)]
        public string Chassis { get; set; }
        [Required]
        [StringLength(255)]
        public string Type { get; set; }
        [Required]
        [StringLength(255)]
        public string CC { get; set; }
        [Required]
        [StringLength(255)]
        public string Value { get; set; }
        public Brand  Brand { get; set; }



    }
}
