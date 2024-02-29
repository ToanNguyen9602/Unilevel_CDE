using Microsoft.EntityFrameworkCore;
using Unilevel_CDE_Dev.Models;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"];
builder.Services.AddDbContext<DatabaseContext>(option => option.UseLazyLoadingProxies().UseSqlServer(connectionString));

app.MapGet("/", () => "Hello World!");

app.Run();
