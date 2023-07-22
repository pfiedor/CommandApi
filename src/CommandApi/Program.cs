using CommandApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<ICommandApiRepo, MockCommandApiRepo>();

var app = builder.Build();

app.UseRouting();
app.MapControllers();

app.Run();
