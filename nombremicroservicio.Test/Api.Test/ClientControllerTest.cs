using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using nombremicroservicio.API;
using nombremicroservicio.Domain.Exceptions;
using nombremicroservicio.Domain.Interfaces;
using nombremicroservicio.Entities;
using nombremicroservicio.Repository.Client.Command;
using nombremicroservicio.Repository.Client.Queries;
using nombremicroservicio.Test.Api.Test;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
namespace nombremicroservicio.Api.Tests
{
    [TestClass]
public class ClientControllerTest
    {
    readonly WebapiAppFactory<Startup> _AppFactory;
    readonly Guid _assigmentId;
    public ClientControllerTest()
    {
        _AppFactory = new WebapiAppFactory<Startup>();
        _assigmentId = Guid.NewGuid();
        SeedDataBase(_AppFactory.Services);
    }

    void SeedDataBase(IServiceProvider provider)
    {
        using (var scope = provider.CreateScope())
        {
            var _assigmentRepository = scope.ServiceProvider
                .GetRequiredService<IGenericRepository<Client>>();
            _ = _assigmentRepository.AddAsync(new Client
            {
                Id = _assigmentId,
                Names = "Names",
                Address = "Cra # 123",
                Age = "23",
                BirthDate = DateTime.Now,
                CreditSubject = "Sujeto",
                IdentificationNumber = "123",
                LastNames = "LastNames",
                MaterialStatus = "Soltero",
                Phone = "3123132",
                SpoceIdentification = "1312",
                SpoceName = "nombre Esposa" 
            }).Result;
        }
    }

    [TestMethod]
    public async Task FindClientSuccess()
    {
        var client = _AppFactory.CreateClient();
        var response = await client.GetAsync($"cliente/{_assigmentId.ToString()}");
        response.EnsureSuccessStatusCode();
        var assigment = JsonSerializer
        .Deserialize<ClientDto>(await response.Content.ReadAsStringAsync(), new System.Text.Json.JsonSerializerOptions
        {
            PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase
        });
        Assert.IsTrue(assigment is not null);
    }

    [TestMethod]
    public async Task RegisterClientDuplicateFailure()
    {
        HttpResponseMessage response = null;

        try
        {
            var client = _AppFactory.CreateClient();
            var request = new CreateClientCommand("123","Name","20",DateTime.Now,"LastName","Dir # 1", "314343", "Soltero", "2134", "Nombre Esposa", "Sujeto");
            var requestContent = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
            response = await client.PostAsync("cliente", requestContent);
            response.EnsureSuccessStatusCode();
        }
        catch (System.Exception)
        {
                Assert.AreEqual(null, response);
        }
    }

    [TestMethod]
    public async Task RegisterClientFailure()
    {
        HttpResponseMessage response = null;

        try
        {
            var client = _AppFactory.CreateClient();
            var request = new CreateClientCommand("123", "Name", "20", DateTime.Now, "LastName", "Dir # 1", "314343", "Soltero", "2134", "Nombre Esposa", "Sujeto");
                var requestContent = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
            response = await client.PostAsync("cliente", requestContent);
            response.EnsureSuccessStatusCode();
        }
        catch (Exception)
        {
            Assert.AreEqual(null, response);
        }

    }





    

}
}