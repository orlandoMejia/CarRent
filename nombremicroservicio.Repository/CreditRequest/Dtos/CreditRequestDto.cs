using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static nombremicroservicio.Entities.CreditRequest;

namespace nombremicroservicio.Repository.CreditRequest.Queries
{
    public class CreditRequestDto
    {
        public string Name { get; set; } = default!;
        public DateTime CreateDate { get; set; } = default!;
        public string Place{ get; set; } = default!;
        public string Vehicle{ get; set; } = default!;
        public string Months{ get; set; } = default!;
        public string Quota{ get; set; } = default!;
        public string Entry{ get; set; } = default!;
        public CreditRequestType RequestType{ get; set; } = default!;
        public Entities.Client Client{ get; set; } = default!;
        public Entities.Executive Executive{ get; set; } = default!;
        public Entities.Brand Brand{ get; set; } = default!;
        public Entities.DriveWay DriveWay{ get; set; } = default!;
        public string Observation { get; set; } = default!;

        public CreditRequestDto()
        {
        }



    }
}
