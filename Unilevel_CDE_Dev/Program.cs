using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using Unilevel_CDE_Dev.Converters;
using Unilevel_CDE_Dev.Models;
using Unilevel_CDE_Dev.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(option => {
    option.JsonSerializerOptions.Converters.Add(new DateTimeConverters());
});

var connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"];
builder.Services.AddDbContext<DatabaseContext>(option => option.UseLazyLoadingProxies().UseSqlServer(connectionString));

builder.Services.AddScoped<AccountService, AccountServiceImpl>();
builder.Services.AddScoped<AreaService, AreaServiceImpl>();
builder.Services.AddScoped<PositionGroupService, PositionGroupServiceImpl>();
builder.Services.AddScoped<DistributorService, DistributorServiceImpl>();


var app = builder.Build();

app.MapControllers();
app.Run();
