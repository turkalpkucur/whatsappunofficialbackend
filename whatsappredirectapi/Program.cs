using Microsoft.EntityFrameworkCore;
using whatsappredirectapi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<WeaseDbContext>(options =>
    options.UseNpgsql("Server=localhost;Port=5432;Database=wease_prod_localdb;User Id=postgres;Password=Wease@47"));
var app = builder.Build();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
 
 

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("", "");
    });
 
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
