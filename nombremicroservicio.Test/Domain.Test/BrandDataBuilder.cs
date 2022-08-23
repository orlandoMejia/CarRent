using nombremicroservicio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nombremicroservicio.Test
{
    public class BrandDataBuilder
    {
        string Name;

        public Brand Build()
        {
            Brand client = new();
            client.Id = Guid.NewGuid();
            return client;
        }

        
        public BrandDataBuilder WithNames(string name)
        {
            Name = name;
            return this;
        }
    }

    
}
