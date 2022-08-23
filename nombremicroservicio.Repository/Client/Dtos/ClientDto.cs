using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nombremicroservicio.Repository.Client.Queries
{
    public class ClientDto
    {

        public string IdentificationNumber { get; set; }

        public string Names { get; set; } = default!;

        public string Age { get; set; }
        public DateTime BirthDate { get; set; }

        public string LastNames { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string MaterialStatus { get; set; }

        public string SpoceIdentification { get; set; }

        public string SpoceName { get; set; }

        public string CreditSubject { get; set; }

        public ClientDto()
        {
        }



    }
}
