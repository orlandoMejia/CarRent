using nombremicroservicio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nombremicroservicio.Test
{
    public class ExecutiveDataBuilder
    {
        string IdentificationNumber;
        string Names;
        string LastNames;
        string Address;
        string Phone;
        string Celphone;
        string DriveWay;
        string Age;

        public Executive Build()
        {
            Executive client = new();
            client.Id = Guid.NewGuid();
            return client;
        }

        public ExecutiveDataBuilder WithIdentificationNumber(string identificationNumber)
        {
            IdentificationNumber = identificationNumber;
            return this;
        }
        public ExecutiveDataBuilder WithNames(string names)
        {
            Names = names;
            return this;
        }
        public ExecutiveDataBuilder WithLastNames(string lastNames)
        {
            LastNames = lastNames;
            return this;
        }
        public ExecutiveDataBuilder WithAddress(string address)
        {
            Address = address;
            return this;
        }
        public ExecutiveDataBuilder WithPhone(string phone)
        {
            Phone = phone;
            return this;
        }
        public ExecutiveDataBuilder WithCelPhone(string celphone)
        {
            Phone = celphone;
            return this;
        }
        public ExecutiveDataBuilder WithDriveWay(string driveWay)
        {
            DriveWay = driveWay;
            return this;
        }
        public ExecutiveDataBuilder WithAge(string age)
        {
            Age = age;
            return this;
        }
        
    }

   
}
