using Booking.API.Infrastructure;
using Booking.Application;
using Booking.Infrastructure;
using Booking.Infrastructure.Database.Seed;
using Carter;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, loggerConfig) =>
        loggerConfig.ReadFrom.Configuration(context.Configuration));

builder.Services.RegisterInfrastructure(builder.Configuration)
    .RegisterApplication()
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddEndpointsApiExplorer()
    .AddCarter()
    .AddSwaggerGen()
    .AddProblemDetails()
    .AddExceptionHandler<GlobalExceptionHandler>();

var app = builder.Build();

using var scope = app.Services.CreateScope();
var rootPath = scope.ServiceProvider.GetRequiredService<IWebHostEnvironment>().ContentRootPath;
var databaseInitializer = scope.ServiceProvider.GetRequiredService<DatabaseInitializer>();
await databaseInitializer.InitializeAsync(rootPath);


app.UseExceptionHandler();
app.UseHttpsRedirection();
app.UseSwagger();
app.UseSwaggerUI();
app.MapCarter();
app.UseSerilogRequestLogging();
app.Run();
