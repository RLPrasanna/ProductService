using Microsoft.EntityFrameworkCore;
using ProductService;
using ProductService.Exceptions;
using ProductService.InheritanceDemo;
using ProductService.InheritanceDemo.TablePerHierarchy;
using ProductService.Services;
using ProductService.ThirdPartyClients.FakeStore;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);


builder.ConfigureServices().ConfigurePipeline().Run();
