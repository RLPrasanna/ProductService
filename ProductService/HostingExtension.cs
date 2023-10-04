using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ProductService.Exceptions;
using ProductService.InheritanceDemo;
using ProductService.Services;
using ProductService.ThirdPartyClients.FakeStore;

namespace ProductService
{
    public static class HostingExtension
    {
        /// <summary>
        /// Add services to the container.
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
        {
            //var config = new ConfigurationBuilder()
            //    .SetBasePath(Directory.GetCurrentDirectory())
            //    .AddJsonFile("appsettings.json")
            //    .Build();

            //builder.Services.AddSingleton<IConfiguration>(config);

            // Controllers
            builder.Services.AddControllers();

            // Swagger/OpenAPI
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // HTTP Client
            builder.Services.AddHttpClient();

            // builder.Services
            builder.Services.AddScoped<IProductService, FakeStoreProductService>();
            builder.Services.AddTransient<ProductService.Services.ProductService>();
            builder.Services.AddTransient<FakeStoryProductServiceClient>();

            // Repositories
            builder.Services.AddScoped<ProductService.InheritanceDemo.TablePerHierarchy.MentorRepository>();
            builder.Services.AddScoped<ProductService.InheritanceDemo.TablePerHierarchy.UserRepository>();
            builder.Services.AddScoped<ProductService.InheritanceDemo.TablePerConcreteType.MentorRepository>();
            builder.Services.AddScoped<ProductService.InheritanceDemo.TablePerConcreteType.StudentRepository>();
            builder.Services.AddScoped<ProductService.InheritanceDemo.TablePerType.MentorRepository>();
            builder.Services.AddScoped<ProductService.InheritanceDemo.TablePerType.StudentRepository>();
            builder.Services.AddScoped<ProductService.InheritanceDemo.ComplexType.MentorRepository>();
            builder.Services.AddScoped<ProductService.InheritanceDemo.ComplexType.StudentRepository>();

            // Database
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseConnection")));


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            return builder.Build();
        }


        /// <summary>
        ///  Configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static WebApplication ConfigurePipeline(this WebApplication app)
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseMiddleware<ExceptionMiddleware>();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            using (var scope = app.Services.CreateScope())
            {
                var repositoryTest = new RepositoryTest(scope.ServiceProvider);
                repositoryTest.RunRepositoryTests();
            }

            return app;
        }

    }
}
