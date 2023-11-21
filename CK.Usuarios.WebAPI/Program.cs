using Octoplex.Usuarios.Domain.Usuarios;
using Octoplex.Usuarios.Infra.Data.Contexts;
using Octoplex.Usuarios.Infra.Data.Usuarios;
using Octoplex.Usuarios.Web.Application.Features.Usuarios.Commands;
using Octoplex.Usuarios.WebAPI.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
//public IWebHostEnvironment WebHostEnvironment { get; }

// Add services to the container / ConfigureServices.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddMediatR(typeof(UsuarioCommand));
builder.Services.AddControllers();
builder.Services.AddCors();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

//Pegando a KeySecret do appSettings
var key = Encoding.ASCII.GetBytes(builder.Configuration.GetSection("SettingsSecret").GetSection("Secret").Value);

//Adicionando Authenticação
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "CK.Usuarios.WebAPI", Version = "v1" });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

builder.Services.AddHttpClient();
builder.Services.AddHttpContextAccessor();
builder.Services.AddLogging(config =>
{
    config.AddDebug();
    config.AddConsole();
    config.AddEventLog();
});


builder.Services.AddMvc();

#region DBContextFactory
//services.AddDbContextFactory<EmpresaDbContext>(
//options =>
//options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=BDCK"));
#endregion

builder.Services.UseDbContext<UsuarioDbContext>(builder.Configuration);

//Interface(Domain),  Implementacao (Infra.Data)
//Registrando Scopo (<IEmpresaRepository, EmpresaRepository>)
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();

#region Adicionando Contexto antes de implementar o Extension Method

//services.AddDbContext<EmpresaDbContext>(options =>
//options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

#endregion

builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline / Configure.

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "CK.Usuarios.WebAPI v1");
    });
}

// Habilita o middleware para redicionar as requisições HTTP para HTTPS
app.UseHsts();
app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();

app.UseCors(corss => corss
    .WithOrigins(builder.Configuration.GetSection("CORSSettings").GetSection("Origins").Value)
    .WithMethods(builder.Configuration.GetSection("CORSSettings").GetSection("Methods").Value)
    .WithHeaders(builder.Configuration.GetSection("CORSSettings").GetSection("Headers").Value)
    .Build());

app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

//app.ApplyMigrations(WebHostEnvironment);

app.Run();