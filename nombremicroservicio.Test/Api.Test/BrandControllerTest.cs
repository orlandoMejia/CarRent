using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using nombremicroservicio.API;
using nombremicroservicio.Domain.Interfaces;
using nombremicroservicio.Entities;
using nombremicroservicio.Repository.Brand.Command;
using nombremicroservicio.Repository.Brand.Queries;
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
public class BrandControllerTest
{
    readonly WebapiAppFactory<Startup> _AppFactory;
    readonly Guid _brandId;
    public BrandControllerTest()
    {
        _AppFactory = new WebapiAppFactory<Startup>();
        _brandId = Guid.NewGuid();
        SeedDataBase(_AppFactory.Services);
    }

    void SeedDataBase(IServiceProvider provider)
    {
        using (var scope = provider.CreateScope())
        {
            var _brandRepository = scope.ServiceProvider
                .GetRequiredService<IGenericRepository<Brand>>();
            _ = _brandRepository.AddAsync(new Brand
            {
                Id = _brandId,
                Name = "BrandTest"
            }).Result;
        }
    }

    [TestMethod]
    public async Task FindBrandSuccess()
    {
        var client = _AppFactory.CreateClient();
        var response = await client.GetAsync($"marca/{_brandId.ToString()}");
        response.EnsureSuccessStatusCode();
        var brand = JsonSerializer
        .Deserialize<BrandDto>(await response.Content.ReadAsStringAsync(), new System.Text.Json.JsonSerializerOptions
        {
            PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase
        });
        Assert.IsTrue(brand.Name.Equals("BrandTest"));
    }

    [TestMethod]
    public async Task RegisterBrandDuplicateFailure()
    {
        HttpResponseMessage response = null;

        try
        {
            var client = _AppFactory.CreateClient();
            var request = new CreateBrandCommand("BrandTest");
            var requestContent = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
            response = await client.PostAsync("marca", requestContent);
            response.EnsureSuccessStatusCode();
        }
        catch (System.Exception)
        {
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }

    [TestMethod]
    public async Task RegisterBrandFailure()
    {
        HttpResponseMessage response = null;

        try
        {
            var client = _AppFactory.CreateClient();
            var request = new CreateBrandCommand("");
            var requestContent = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
            response = await client.PostAsync("marca", requestContent);
            response.EnsureSuccessStatusCode();
        }
        catch (Exception)
        {
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

    }



    [TestMethod]
    public async Task RegisterBrandSuccess()
    {
        var client = _AppFactory.CreateClient();
        var request = new CreateBrandCommand("BrandTestSuccess");
        var requestContent = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
        var response = await client.PostAsync("marca", requestContent);
        response.EnsureSuccessStatusCode();
        Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
    }

    

}
}