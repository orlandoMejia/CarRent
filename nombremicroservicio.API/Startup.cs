using System;
using System.IO;
using System.Diagnostics;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OpenTelemetry.Exporter;
using OpenTelemetry.Instrumentation.AspNetCore;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using OpenTelemetry.Logs;
using Microsoft.OpenApi;
using Microsoft.OpenApi.Models;
using nombremicroservicio.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System.Linq;
using nombremicroservicio.Infrastructure.Services;
using nombremicroservicio.Repository.Client.Command;
using nombremicroservicio.Domain.Interfaces;
using nombremicroservicio.Repository;

namespace nombremicroservicio.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
           

            #region OPENTELEMETRY
            string otelServer = Environment.GetEnvironmentVariable("OTEL_SERVER");
            Console.WriteLine(otelServer);
            var serviceName = System.Reflection.Assembly.GetEntryAssembly().GetName().Name;

            services.AddHttpContextAccessor();
            if (!String.IsNullOrEmpty(otelServer))
            {
                services.AddOpenTelemetryTracing(builder =>
                   builder
                  .AddAspNetCoreInstrumentation()
                  .AddHttpClientInstrumentation()
                  .AddConsoleExporter()
                  .AddZipkinExporter(options =>
                  {
                      options.Endpoint = new Uri($"http://{otelServer}:9411/api/v2/spans");
                  })
                  .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService(serviceName))
                );
            }

            services.AddLogging(logging =>
            {
                logging.AddOpenTelemetry(options =>
                {
                    options.AddConsoleExporter();
                });
            });

            #endregion OPENTELEMETRY

            #region INFRASTRUCTURE

            services.AddDbContext<PersistenceContext>(opt =>
            {
                opt.UseNpgsql(Configuration.GetConnectionString("database"), options =>
                {
                    options.MigrationsHistoryTable("_MigrationHistory", Configuration.GetValue<string>("SchemaName"));
                });
            });


            #endregion INFRASTRUCTURE

            #region COMPATIBILITY
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            #endregion COMPATIBILITY

            #region HANDLING API VERSIONS
            services.AddApiVersioning(options => options.UseApiBehavior = true);
            services.AddApiVersioning(options => options.AssumeDefaultVersionWhenUnspecified = true);
            #endregion HANDLING API VERSIONS

            #region POLICY FOR CORS DOMAIN
            services.AddCors(options => options.AddPolicy("AllowAll", p => p.AllowAnyOrigin()
                                                                   .AllowAnyMethod()
                                                                   .AllowAnyHeader()));
            #endregion POLICY FOR CORS DOMAIN

            services.AddMediatR(Assembly.Load("nombremicroservicio.Repository"));

            services.AddTransient<BrandService>();
            services.AddTransient<ClientService>();
            services.AddTransient<CreditRequestService>();
            services.AddTransient<DriveWayService>();
            services.AddTransient<ExecutiveService>();
            services.AddTransient<AssigmentService>();

            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddControllers();

            var applicationAssemblyName = typeof(Startup).Assembly.GetReferencedAssemblies()
                .FirstOrDefault(x => x.Name.Equals("nombremicroservicio.Repository", StringComparison.InvariantCulture));

            services.AddAutoMapper(Assembly.Load(applicationAssemblyName.FullName));

            #region Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "nombremicroservicio",
                    Description = "Una descripcion del microservicio",
                    Contact = new OpenApiContact
                    {
                        Name = "Banco Pichincha",
                        Email = "devops@pichincha.com",
                        Url = new Uri("https://www.pichincha.com"),
                    }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            #endregion Swagger
        }




        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            #region SwaggerUI
            app.UseStaticFiles();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "nombremicroservicio API");
                c.RoutePrefix = "swagger";
                c.InjectStylesheet("/swagger/custom.css");
            });
            #endregion Swagger
            app.UseRouting();

            app.UseAuthorization();

            app.UseCors("AllowAll");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
