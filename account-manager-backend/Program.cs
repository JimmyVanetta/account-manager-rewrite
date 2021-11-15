using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using account_manager_backend.Data;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<account_manager_backendContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("account_manager_backendContext")));


// Add services to the container.

builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
