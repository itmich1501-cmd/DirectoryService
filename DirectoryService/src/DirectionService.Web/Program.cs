using DirectionService.Infrastructure.Postgres;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddScoped<DepartmentServiceDbContext>(_ =>
    new DepartmentServiceDbContext(builder.Configuration.GetConnectionString("DepartmentServiceDb")!));

//builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    // app.MapOpenApi();
    // app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", "DirectionService v1"));
}

app.MapControllers();

app.Run();