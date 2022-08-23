using nombremicroservicio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nombremicroservicio.Test
{
    public class DrivewayDataBuilder
    {
        string Name;
        string Address;
        string Phone;
        string SalesNumber;


        public DriveWay Build()
        {
            DriveWay driveWay = new();
            driveWay.Id = Guid.NewGuid();
            return driveWay;
        }


        public DrivewayDataBuilder WithName(string name)
        {
            Name = name;
            return this;
        }

        public DrivewayDataBuilder WithAddress(string address)
        {
            Address = address;
            return this;
        }

        public DrivewayDataBuilder WithPhone(string phone)
        {
            Phone = phone;
            return this;
        }

        public DrivewayDataBuilder WithSalesNumber(string salesNumber)
        {
            SalesNumber = salesNumber;
            return this;
        }
       
    }

    
}
