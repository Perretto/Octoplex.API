using Octoplex.Empresas.Domain.Empresas;
using Octoplex.Empresas.Infra.Data.Contexts;
using Octoplex.Empresas.Infra.Data.Empresas;
using Octoplex.Empresas.WebAPI.Extensions;
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
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Octoplex.Empresas.WebAPI", Version = "v1" });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

builder.Services.AddHttpClient();
builder.Services.AddHttpContextAccessor();
builder.Services.AddMvc();

#region DBContextFactory
//services.AddDbContextFactory<EmpresaDbContext>(
//options =>
//options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=BDCK"));
#endregion

builder.Services.UseDbContext<EmpresaDbContext>(builder.Configuration);

//Interface(Domain),  Implementacao (Infra.Data)
//Registrando Scopo (<IEmpresaRepository, EmpresaRepository>)
builder.Services.AddScoped<IEmpresaRepository, EmpresaRepository>();
builder.Services.AddTransient<IEmpresaRepository, EmpresaRepository>();

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
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Octoplex.Empresas.WebAPI v1");
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