using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nombremicroservicio.Entities
{
    public class Client
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(255)]

        public string IdentificationNumber { get; set; }
        [Required]
        [StringLength(255)]

        public string Names { get; set; } = default!;
        [Required]
        [StringLength(255)]

        public string Age { get; set; }
        public DateTime BirthDate { get; set; }
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

        public string MaterialStatus { get; set; }
        [Required]
        [StringLength(255)]

        public string SpoceIdentification { get; set; }
        [Required]
        [StringLength(255)]

        public string SpoceName { get; set; }
        [Required]
        [StringLength(255)]

        public string CreditSubject { get; set; }

        public Client(Guid id, string identificationNumber, string names, string age,
            DateTime birthDate, string lastNames, string address, string phone,
            string materialStatus, string spoceIdentification,
            string spoceName, string creditSubject)
        {
            Id = id;
            IdentificationNumber = identificationNumber;
            Names = names;
            Age = age;
            BirthDate = birthDate;
            LastNames = lastNames;
            Address = address;
            Phone = phone;
            MaterialStatus = materialStatus;
            SpoceIdentification = spoceIdentification;
            SpoceName = spoceName;
            CreditSubject = creditSubject;
        }

        public Client()
        {
        }
    }
}
