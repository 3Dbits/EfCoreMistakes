using EfCoreMistakes.Data;
using EfCoreMistakes.Endpoints;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<EfCoreMistakesContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("EfCoreMistakesContext") ?? throw new InvalidOperationException("Connection string 'EfCoreMistakesContext' not found.")));

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

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapSomeModelEndpoints();

app.MapSubModelEndpoints();

app.MapSubSubModelEndpoints();

app.MapSubSubSubModelEndpoints();

app.Run();
