using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nombremicroservicio.Entities
{
    public class CreditRequest
    {
        public Guid Id { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        [Required]
        [StringLength(255)]
        public string Place { get; set; }
        [Required]
        [StringLength(255)]

        public string Vehicle { get; set; }
        [Required]
        [StringLength(255)]

        public string Months { get; set; }
        [Required]
        [StringLength(255)]

        public string Quota { get; set; }
        [Required]
        [StringLength(255)]

        public string Entry { get; set; }
        [Required]
        public CreditRequestType RequestType { get; set; }
        [Required]
        [StringLength(255)]
        public Guid IdClient { get; set; }
        [Required]
        public Guid IdExecutive { get; set; }
        [Required]
        public Guid IdBrand { get; set; }
        [Required]
        public Guid IdDriveWay { get; set; }
        [StringLength(255)]

        public string Observation { get; set; }

        public enum CreditRequestType { Registrada, Despachada, Cancelada}

    }
}
