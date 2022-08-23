using nombremicroservicio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nombremicroservicio.Test
{
    public class ClientDataBuilder
    {
        string IdentificationNumber;
        string Names;
        string Age;
        string BirthDate;
        string LastNames;
        string Address;
        string Phone;
        string MaterialStatus;
        string SpoceIdentification;
        string SpoceName;
        string CreditSubject;

        public Client Build()
        {
            Client client = new ();
            client.Id = Guid.NewGuid();
            return client;
        }

        public ClientDataBuilder WithIdentificationNumber(string identificationNumber)
        {
            IdentificationNumber = identificationNumber;
            return this;
        }
        public ClientDataBuilder WithNames(string names)
        {
            Names = names;
            return this;
        }
        public ClientDataBuilder WithAge(string age)
        {
            Age = age;
            return this;
        }
        public ClientDataBuilder WithBirthDate(string birthDate)
        {
            BirthDate = birthDate;
            return this;
        }
        public ClientDataBuilder WithLastNames(string lastNames)
        {
            LastNames = lastNames;
            return this;
        }
        public ClientDataBuilder WithAddress(string address)
        {
            Address = address;
            return this;
        }
        public ClientDataBuilder WithPhone(string phone)
        {
            Phone = phone;
            return this;
        }
        public ClientDataBuilder WithMaterialStatus(string materialStatus)
        {
            MaterialStatus = materialStatus;
            return this;
        }
        public ClientDataBuilder WithSpoceIdentification(string spoceIdentification)
        {
            SpoceIdentification = spoceIdentification;
            return this;
        }
        public ClientDataBuilder WithSpoceName(string spoceName)
        {
            SpoceName = spoceName;
            return this;
        }
        public ClientDataBuilder WithCreditSubject(string creditSubject)
        {
            CreditSubject = creditSubject;
            return this;
        }
    }

}
