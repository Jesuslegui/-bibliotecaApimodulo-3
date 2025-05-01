using System.Text.Json.Serialization;
using _bibliotecaApi;
using _bibliotecaApi.Datos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Area de Servicios

builder.Services.AddTransient<ServicioTransient>();
builder.Services.AddScoped<ServicioScoped>();
builder.Services.AddSingleton<ServicioSingleton>();

//prueba
builder.Services.AddSingleton<IRepositorioValores, RepositorioValoresOracle>();


builder.Services.AddControllers().AddJsonOptions(opciones => opciones
.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddDbContext<ApplicationDbContext>(Opciones => 
Opciones.UseSqlServer("name=DefaultConnection"));

var app = builder.Build();

//area de los middleware

app.UseLogueaPeticion();



app.UseBloqueadorPeticion();

app.MapControllers();//despues de este de devuelve la funcion

app.Run();
