using DirectionService.Application;
using DirectionService.Application.Locations;
using DirectionService.Infrastructure.Postgres;
using DirectionService.Infrastructure.Postgres.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddApplication();

builder.Services.AddScoped<ILocationRepository, LocationRepository>();

builder.Services.AddScoped<DepartmentServiceDbContext>(_ =>
    new DepartmentServiceDbContext(builder.Configuration.GetConnectionString("DepartmentServiceDb")!));

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", "DirectionService v1"));
}

app.MapControllers();

app.Run();