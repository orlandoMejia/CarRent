using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using nombremicroservicio.Infrastructure.Persistence;
using nombremicroservicio.API;
using Microsoft.AspNetCore.Mvc.Testing;

namespace nombremicroservicio.Test.Api.Test
{
    public class WebapiAppFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override IHostBuilder CreateHostBuilder()
        {

            return Host.CreateDefaultBuilder()
                .ConfigureWebHostDefaults(builder =>
                {
                    builder.UseStartup<Startup>().ConfigureServices(services =>
                    {
                        var dbCtxOpts = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<PersistenceContext>));

                        if (dbCtxOpts != null)
                        {
                            services.Remove(dbCtxOpts);
                        }

                        services.AddDbContext<PersistenceContext>(options =>
                        {
                            options.UseInMemoryDatabase("TestDb");
                        });

                    });
                });

        }
    }
}
