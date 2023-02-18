using eLibrary.Models;
using eLibrary.WebApi.MinimalApi.Endpoints;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHealthChecks();
builder.Services.AddSingleton<BookRepository>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x =>
{
    var filePath1 = Path.Combine(System.AppContext.BaseDirectory, "eLibrary.Models.xml");
    var filePath2 = Path.Combine(System.AppContext.BaseDirectory, "eLibrary.WebApi.MinimalApi.xml");
    x.IncludeXmlComments(filePath1);
    x.IncludeXmlComments(filePath2);
});

builder.Services.Configure<Microsoft.AspNetCore.Mvc.MvcOptions>(options =>
{
    options.OutputFormatters.Clear();
    options.OutputFormatters.Add(
        new Microsoft.AspNetCore.Mvc.Formatters.SystemTextJsonOutputFormatter(
            new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            }));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapHealthEndpoints();
app.MapBookEndpoints();

app.Run();
