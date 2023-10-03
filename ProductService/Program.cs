using Microsoft.EntityFrameworkCore;
using ProductService;
using ProductService.Exceptions;
using ProductService.InheritanceDemo;
using ProductService.InheritanceDemo.TablePerHierarchy;
using ProductService.Services;
using ProductService.ThirdPartyClients.FakeStore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();
builder.Services.AddScoped<IProductService, FakeStoreProductService>();
builder.Services.AddTransient<ProductService.Services.ProductService>();
builder.Services.AddTransient<FakeStoryProductServiceClient>();

builder.Services.AddScoped<MentorRepository>();
builder.Services.AddScoped<UserRepository>();


builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseConnection")));

var app = builder.Build();

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

app.Run();
