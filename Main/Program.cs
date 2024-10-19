using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using DataBase;
using Main.services;
using Main.Store.services;
using Main.repositories;
using Main.Store.repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connStr = builder.Configuration
    .GetValue<string>("ConnectionStrings:Db"); 

// string connStr = builder.Configuration
//     .GetValue<string>("ConnectionStrings:IcTiendaDb");
// string linkDataBase = "workstation id=Creation-CRUD.mssql.somee.com;packet size=4096;user id=h4ndx_SQLLogin_1;pwd=vv2skmgumo;data source=Creation-CRUD.mssql.somee.com;persist security info=False;initial catalog=Creation-CRUD;TrustServerCertificate=True";

builder.Services.AddDbContext<MiDbContext>(
    // Connect to SqlServer
    (config) => config.UseSqlServer(
        connStr, b => b.MigrationsAssembly("Main"))
);

string web = builder.Configuration.GetValue<string>("CORS:web");
string web2 = builder.Configuration.GetValue<string>("CORS:web2");


builder.Services.AddCors(
    (conf) => conf.AddDefaultPolicy( policy => 
        policy.AllowAnyHeader()
            .AllowAnyMethod()
            //.AllowAnyOrigin()
            .WithMethods()
            .WithOrigins(web, web2)
    )
);
 

/* builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.WithOrigins(webFront, webFront2)
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
}); */


builder.Services.AddScoped<IPersonService, PersonServiceDbImpl>();
// repositories
builder.Services.AddScoped<IPersonRepository, PersonRepositoryImpl>();

var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI();

app.UseHttpsRedirection();  

app.UseRouting();

app.UseAuthorization();
        
app.MapControllers();

app.UseCors();

app.Run();