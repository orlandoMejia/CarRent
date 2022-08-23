using nombremicroservicio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nombremicroservicio.Test
{
    public class AssigmentDataBuilder
    {
        string Name;
        DateTime Date;
        Client Client;
        DriveWay DriveWay;


        public Assigment Build()
        {
            Assigment assigment = new();
            assigment.Id = Guid.NewGuid();
            return assigment;
        }


        public AssigmentDataBuilder WithDate(DateTime date)
        {
            Date = date;
            return this;
        }

        public AssigmentDataBuilder WithClient(Client client)
        {
            Client = client;
            return this;
        }

        public AssigmentDataBuilder WithDriveWay(DriveWay driveWay)
        {
            DriveWay = driveWay;
            return this;
        }

       
    }

    
}
