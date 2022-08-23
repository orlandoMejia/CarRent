using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using nombremicroservicio.API;
using nombremicroservicio.Domain.Interfaces;
using nombremicroservicio.Entities;
using nombremicroservicio.Repository.DriveWay.Command;
using nombremicroservicio.Repository.DriveWay.Queries;
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
public class DriveWayControllerTest
    {
    readonly WebapiAppFactory<Startup> _AppFactory;
    readonly Guid _driveWayId;
    public DriveWayControllerTest()
    {
        _AppFactory = new WebapiAppFactory<Startup>();
        _driveWayId = Guid.NewGuid();
        SeedDataBase(_AppFactory.Services);
    }

    void SeedDataBase(IServiceProvider provider)
    {
        using (var scope = provider.CreateScope())
        {
            var _driveWayRepository = scope.ServiceProvider
                .GetRequiredService<IGenericRepository<DriveWay>>();
            _ = _driveWayRepository.AddAsync(new DriveWay
            {
                Id = _driveWayId,
                Name = "DriveWayTest",
                Address = "Cra 24 N #12",
                Phone = "325665456",
                Number ="056"
            }).Result;
        }
    }

    [TestMethod]
    public async Task FindDriveWaySuccess()
    {
        var client = _AppFactory.CreateClient();
        var response = await client.GetAsync($"patio/{_driveWayId.ToString()}");
        response.EnsureSuccessStatusCode();
        var driveWay = JsonSerializer
        .Deserialize<DriveWayDto>(await response.Content.ReadAsStringAsync(), new System.Text.Json.JsonSerializerOptions
        {
            PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase
        });
        Assert.IsTrue(driveWay.Name.Equals("DriveWayTest"));
    }

    [TestMethod]
    public async Task RegisterDriveWayDuplicateFailure()
    {
        HttpResponseMessage response = null;

        try
        {
            var client = _AppFactory.CreateClient();
            var request = new CreateDriveWayCommand("DriveWayTest" , "Cra 1 S #12" , "315665456", "756");
            var requestContent = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
            response = await client.PostAsync("patio", requestContent);
            response.EnsureSuccessStatusCode();
        }
        catch (System.Exception)
        {
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }

    [TestMethod]
    public async Task RegisterDriveWayFailure()
    {
        HttpResponseMessage response = null;

        try
        {
            var client = _AppFactory.CreateClient();
            var request = new CreateDriveWayCommand("DriveWayTest", "Cra 24 N #12", "325665456", "056");

            var requestContent = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
            response = await client.PostAsync("patio", requestContent);
            response.EnsureSuccessStatusCode();
        }
        catch (Exception)
        {
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

    }



    [TestMethod]
    public async Task RegisterDriveWaySuccess()
    {
        var client = _AppFactory.CreateClient();
        var request = new CreateDriveWayCommand("DriveWaySuccess", "Cra 54 N #12", "375665456", "999");
        var requestContent = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
        var response = await client.PostAsync("patio", requestContent);
        response.EnsureSuccessStatusCode();
        Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
    }

    

}
}