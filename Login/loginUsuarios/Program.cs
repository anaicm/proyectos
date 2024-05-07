using loginUsuarios.DataContext;
using loginUsuarios.entidades;
using loginUsuarios.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var configuration = builder.Configuration; // Settings from appsettings.json included by default
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// AddDbContext => añade el contexto que se esta usando en <UsersContext> que es el acceso a la BD a las tabla que se definen
// en <UsersContext> usando sqlServer con la cadena de conexion.
builder.Services.AddDbContext<UsuarioContext>
(options=>options.UseSqlServer
(@"Data Source=PORTATIL\SQLEXPRESS;Initial Catalog=loginUsuarios;User Id=sa;Password=rootadmin;Encrypt=false"));
//---------------------------
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
  .AddEntityFrameworkStores<UsuarioContext>()
  .AddDefaultTokenProviders();

//Añado la posibilidad de authencation con Cookies
builder.Services.Configure<CookieAuthenticationOptions>(IdentityConstants.ApplicationScheme, configuration.GetSection("CookieAuthentication"));
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

builder.Services.AddScoped<IUsuariosService, UsuariosService>();

builder.Services.AddSwaggerGen();
//-----------------------------------------------------------------------------
var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
