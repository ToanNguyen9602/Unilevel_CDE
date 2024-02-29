using Microsoft.EntityFrameworkCore;
using Unilevel_CDE_Dev.Models;
using Unilevel_CDE_Dev.Services;

var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"];
builder.Services.AddDbContext<DatabaseContext>(option => option.UseLazyLoadingProxies().UseSqlServer(connectionString));

builder.Services.AddScoped<AccountService, AccountServiceImpl>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.Run();
