using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using nombremicroservicio.API;
using nombremicroservicio.Domain.Exceptions;
using nombremicroservicio.Domain.Interfaces;
using nombremicroservicio.Entities;
using nombremicroservicio.Repository.Assigment.Command;
using nombremicroservicio.Repository.Assigment.Queries;
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
public class AssigmentControllerTest
    {
    readonly WebapiAppFactory<Startup> _AppFactory;
    readonly Guid _assigmentId;
    public AssigmentControllerTest()
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
                .GetRequiredService<IGenericRepository<Assigment>>();
            _ = _assigmentRepository.AddAsync(new Assigment
            {
                Id = _assigmentId,
                Date = DateTime.Now
            }).Result;
        }
    }

    [TestMethod]
    public async Task FindAssigmentSuccess()
    {
        var client = _AppFactory.CreateClient();
        var response = await client.GetAsync($"asignacion/{_assigmentId.ToString()}");
        response.EnsureSuccessStatusCode();
        var assigment = JsonSerializer
        .Deserialize<AssigmentDto>(await response.Content.ReadAsStringAsync(), new System.Text.Json.JsonSerializerOptions
        {
            PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase
        });
        Assert.IsTrue(assigment is not null);
    }

    [TestMethod]
    public async Task RegisterAssigmentDuplicateFailure()
    {
        HttpResponseMessage response = null;

        try
        {
            var client = _AppFactory.CreateClient();
            var request = new CreateAssigmentCommand(DateTime.Now, Guid.Empty, Guid.Empty);
            var requestContent = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
            response = await client.PostAsync("asignacion", requestContent);
            response.EnsureSuccessStatusCode();
        }
        catch (System.Exception)
        {
                Assert.AreEqual(null, response);
            }
        }

    [TestMethod]
    public async Task RegisterAssigmentFailure()
    {
        HttpResponseMessage response = null;

        try
        {
            var client = _AppFactory.CreateClient();
            var request = new CreateAssigmentCommand(DateTime.Now, Guid.Empty, Guid.Empty);
            var requestContent = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
            response = await client.PostAsync("asignacion", requestContent);
            response.EnsureSuccessStatusCode();
        }
        catch (Exception)
        {
            Assert.AreEqual(null, response);
        }

    }





    

}
}