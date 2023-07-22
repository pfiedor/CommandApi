using CommandApi.Data;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<ICommandApiRepo, SqlCommandApiRepo>();
builder.Services.AddDbContext<CommandContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSqlConnection")));

var app = builder.Build();

app.UseRouting();
app.MapControllers();

app.Run();
