using nombremicroservicio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static nombremicroservicio.Entities.CreditRequest;

namespace nombremicroservicio.Test
{
    public class CreditRequestDataBuilder
    {
        DateTime CreateDate;
        string Place;
        string Vehicle;
        string Months;
        string Quota;
        string Entry;
        CreditRequestType RequestType;
        Guid Client;
        Guid Executive;
        Guid Brand;
        Guid DriveWay;
        string Observation;

        public CreditRequest Build()
        {
            CreditRequest client = new();
            client.Id = Guid.NewGuid();
            return client;
        }

        public CreditRequestDataBuilder WithCreateDate(DateTime createDate)
        {
            CreateDate = createDate;
            return this;
        }
        public CreditRequestDataBuilder WithPlace(string place)
        {
            Place = place;
            return this;
        }
        public CreditRequestDataBuilder WithVehicle(string vehicle)
        {
            Vehicle = vehicle;
            return this;
        }
        public CreditRequestDataBuilder WithMonths(string months)
        {
            Months = months;
            return this;
        }
        public CreditRequestDataBuilder WithQuota(string quota)
        {
            Quota = quota;
            return this;
        }
        public CreditRequestDataBuilder WithEntry(string entry)
        {
            Entry = entry;
            return this;
        }

        public CreditRequestDataBuilder WithRequestType(CreditRequestType creditRequest)
        {
            RequestType = creditRequest;
            return this;
        }
        public CreditRequestDataBuilder WithClient(Guid client)
        {
            Client = client;
            return this;
        }
        public CreditRequestDataBuilder WithExecutive(Guid executive)
        {
            Executive = executive;
            return this;
        }
        public CreditRequestDataBuilder WithBrand(Guid brand)
        {
            Brand = brand;
            return this;
        }
        public CreditRequestDataBuilder WithDriveWay(Guid driveWay)
        {
            DriveWay = driveWay;
            return this;
        }
        public CreditRequestDataBuilder WithObservation(string observation)
        {
            Observation = observation;
            return this;
        }

    }

    
}
