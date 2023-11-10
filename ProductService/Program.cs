
using ProductService;


var builder = WebApplication.CreateBuilder(args);


builder.ConfigureServices().ConfigurePipeline().Run();
