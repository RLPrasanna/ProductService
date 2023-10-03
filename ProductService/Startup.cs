using ProductService.InheritanceDemo.TablePerHierarchy;

namespace ProductService
{
    public class Startup
    {
        public IConfiguration configuration { get; }

        public Startup(IConfiguration Configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            services.AddSingleton<IConfiguration>(config);

            // Your configuration is available here.
            var apiKey = config["AppSettings:ApiKey"];
        }

    }
}
