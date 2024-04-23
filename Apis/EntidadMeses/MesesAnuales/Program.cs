using MesesAnuales.DataContext;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// AddDbContext => añade el contexto que se esta usando en <UsersContext> que es el acceso a la BD a las tabla que se definen
// en <MesesContext> usando sqlServer con la cadena de conexion.
builder.Services.AddDbContext<MesesContext>
(options=>options.UseSqlServer
(@"Data Source=PORTATIL\SQLEXPRESS;Initial Catalog=Año;User Id=sa;Password=rootadmin;Encrypt=false"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
