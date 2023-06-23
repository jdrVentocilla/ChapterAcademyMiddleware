
using ExampleAPI.Filters;
using ExampleAPI.Middleware;
using ExampleWebAPI.Helpers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using UserITApp.Entities;
using UserITApp.Persistence;
using UserITApp.Services;

var builder = WebApplication.CreateBuilder(args);

//Estandar 
builder.Services.AddCors();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddAuthentication(); 
// Cookies
// JWT

builder.Services.AddLogging();
// Serilog
// LoG

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




builder.Services.AddDbContext<UserITAppContext>(
    options
    => options.UseMySql("Server=64.227.8.152; Database=useritapp; Uid=useritapp; Pwd=#gD09IO1F; CharSet=utf8; Port=3306;",
                     ServerVersion.AutoDetect("Server=64.227.8.152; Database=useritapp; Uid=useritapp; Pwd=#gD09IO1F; CharSet=utf8; Port=3306;  pooling=true;")));


builder.Services.AddTransient<IServicioGenerico<Usuario>, UsuarioService>();
builder.Services.AddTransient<IServicioGenerico<Aplicacion>, AplicacionService>();

//builder.Services.AddMvc(op => { op.EnableEndpointRouting = false;
//                                    op.Filters.Add(typeof(ErrorFilter));
//                                }
//);


builder.Services.AddTransient<ErrorFilter>();
builder.Services.AddTransient<ResponseFactory>();
builder.Services.AddTransient<SuccesResponseFactory>();
builder.Services.AddTransient<ErrorResponseFactory>();

builder.Services.AddTransient<ErrorMiddleware>();
// ---------------


//Crear el app
var app = builder.Build();

//Pipèline

//app.UseMiddleware<ErrorMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.MapControllers();

app.Run();