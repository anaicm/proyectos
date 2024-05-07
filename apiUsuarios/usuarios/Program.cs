
using apiUsuarios.data;
using apiUsuarios.entidades;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// AddDbContext => añade el contexto que se esta usando en <UsersContext> que es el acceso a la BD a las tabla que se definen
// en <UsersContext> usando sqlServer con la cadena de conexion.
builder.Services.AddDbContext<UsersContext>
(options=>options.UseSqlServer
(@"Data Source=PORTATIL\SQLEXPRESS;Initial Catalog=login;User Id=sa;Password=rootadmin;Encrypt=false"));
//--- si hay que añadir mas contextos para consultar cada tabla
builder.Services.AddDbContext<CochesContext>
(options => options.UseSqlServer
(@"Data Source=PORTATIL\SQLEXPRESS;Initial Catalog=login;User Id=sa;Password=rootadmin;Encrypt=false"));
//--- si hay que añadir mas contextos para consultar cada tabla
builder.Services.AddDbContext<MueblesContext>
(options => options.UseSqlServer
(@"Data Source=PORTATIL\SQLEXPRESS;Initial Catalog=login;User Id=sa;Password=rootadmin;Encrypt=false"));
//--- si hay que añadir mas contextos para consultar cada tabla
builder.Services.AddDbContext<CasasContext>
(options => options.UseSqlServer
(@"Data Source=PORTATIL\SQLEXPRESS;Initial Catalog=login;User Id=sa;Password=rootadmin;Encrypt=false"));


//-------------------------Codigo para los usuarios (identity)
// Usuario => como se ha añadido campos nuevos a parte de los que trae por defecto se pone la clase donde estan los campos usuario
// Role => como se ha añadido campos nuevos a parte de los que trae por defecto se pone la clase donde estan los campos Role
builder.Services.AddIdentity<Usuario, Role>(options =>
{
    //restricciones para la contraseña
    //Son opciones para la creación de la contraseña
    options.Password.RequiredLength = 0;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    
})
  .AddEntityFrameworkStores<UsersContext>()
  .AddDefaultTokenProviders();

//Añado la posibilidad de authencation con Cookies
builder.Services.Configure<CookieAuthenticationOptions>(IdentityConstants.ApplicationScheme, options =>
{
    var expireTimeSpanString = "100000";
    if (TimeSpan.TryParse(expireTimeSpanString, out TimeSpan expireTimeSpan))
    {
        options.ExpireTimeSpan = expireTimeSpan;
    }
    // Do not redirect on authentication fail, just set 401
    options.Events.OnRedirectToLogin = context =>
    {
        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
        return Task.CompletedTask;
    };

    options.AccessDeniedPath = "/index.html";
});

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ApiPlayground", Version = "v1" });

    // Agrega la definición de seguridad para cookies
    c.AddSecurityDefinition("cookie", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.Http,
        Scheme = CookieAuthenticationDefaults.AuthenticationScheme, // Utiliza el esquema de autenticación por cookies
        Name = "NombreDeLaCookie", // Nombre de la cookie que se utilizará para almacenar la información de autenticación
        In = ParameterLocation.Cookie, // Especifica que la información de autenticación se enviará en una cookie
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();//hace falta si o si para el login y en este orden
app.UseAuthorization();//hace falta si o si para el login

app.MapControllers();

app.Run();
