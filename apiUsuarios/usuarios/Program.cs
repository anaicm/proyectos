
using apiUsuarios.data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// AddDbContext => a�ade el contexto que se esta usando en <UsersContext> que es el acceso a la BD a las tabla que se definen
// en <UsersContext> usando sqlServer con la cadena de conexion.
builder.Services.AddDbContext<UsersContext>
(options=>options.UseSqlServer
(@"Data Source=PORTATIL\SQLEXPRESS;Initial Catalog=login;User Id=sa;Password=rootadmin;Encrypt=false"));
//--- si hay que a�adir mas contextos para consultar cada tabla
builder.Services.AddDbContext<CochesContext>
(options => options.UseSqlServer
(@"Data Source=PORTATIL\SQLEXPRESS;Initial Catalog=login;User Id=sa;Password=rootadmin;Encrypt=false"));
//--- si hay que a�adir mas contextos para consultar cada tabla
builder.Services.AddDbContext<MueblesContext>
(options => options.UseSqlServer
(@"Data Source=PORTATIL\SQLEXPRESS;Initial Catalog=login;User Id=sa;Password=rootadmin;Encrypt=false"));
//--- si hay que a�adir mas contextos para consultar cada tabla
builder.Services.AddDbContext<CasasContext>
(options => options.UseSqlServer
(@"Data Source=PORTATIL\SQLEXPRESS;Initial Catalog=login;User Id=sa;Password=rootadmin;Encrypt=false"));

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
