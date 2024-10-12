using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using DataBase;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connStr = builder.Configuration
    .GetValue<string>("ConnectionStrings:Db");

// string connStr = builder.Configuration
//     .GetValue<string>("ConnectionStrings:IcTiendaDb");

builder.Services.AddDbContext<DataBase.MiDbContext>(
    // Connect to SqlServer
    (config) => config.UseSqlServer(connStr, b => b.MigrationsAssembly("Main"))
);
 
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();  

app.UseAuthorization();
        
app.MapControllers();

app.UseCors();

app.Run();