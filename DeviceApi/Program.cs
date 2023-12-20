using DeviceApi.Endpoints;
using DeviceManager.Shared.Domain;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

var specOrigin = "MySpecOrigin";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: specOrigin, policy =>
    {
        policy.WithOrigins("https://localhost:7037")
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.RegisterUserEndpoint();
app.UseCors(specOrigin);

app.Run();


