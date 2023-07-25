using CommandApi.Data;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<ICommandApiRepo, SqlCommandApiRepo>();

var cs = new NpgsqlConnectionStringBuilder
{
    ConnectionString = builder.Configuration.GetConnectionString("PostgreSqlConnection"),
    Username = builder.Configuration["UserID"],
    Password = builder.Configuration["Password"]
};

builder.Services.AddDbContext<CommandContext>(options => options.UseNpgsql(cs.ConnectionString));

var app = builder.Build();

app.UseRouting();
app.MapControllers();

app.Run();
