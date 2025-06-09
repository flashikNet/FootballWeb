using Infrastructure;
using Application;

var builder = WebApplication.CreateBuilder(args);


builder.Services
    .AddOpenApi()
    .AddCors()
    .TryAddInfrastructure()
    .TryAddServices()
    .AddControllers();

var app = builder.Build();

app.UseCors(option => option.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app
    .UseHttpsRedirection()
    .UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "OpenAPI V1");
    });

app.MapControllers();

app.Run();