using Octoplex.Produtos.Domain.Produtos;
using Octoplex.Produtos.Infra.Data;
using Octoplex.Produtos.Infra.Data.Contexts;
using Octoplex.Produtos.Infra.Data.Produtos;
using Octoplex.Produtos.Web.Application.Features.Produtos.Commands;
using Octoplex.Produtos.WebAPI.Extensions;
using Octoplex.Produtos.WebAPI.Features.Produtos.Validator;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
//public IWebHostEnvironment WebHostEnvironment { get; }

// Add services to the container / ConfigureServices.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

//builder.Services.AddControllers().AddFluentValidation();
 //Para implementar o FluentValidations AddFluentValidation

//builder.Services.AddTransient<IValidator<Produto>, ProdutoValidator>().AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
builder.Services.AddMediatR(typeof(ProdutoCommand));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers(); //Para implementar o FluentValidations AddFluentValidation

builder.Services.AddCors();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


//Pegando a KeySecret do appSettings
var key = Encoding.ASCII.GetBytes(builder.Configuration.GetSection("SettingsSecret").GetSection("Secret").Value);

//Adicionando Autorização
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("MANAGER", policy => policy.RequireClaim("CkApi", "MANAGER"));
    options.AddPolicy("admin", policy => policy.RequireClaim("CkApi", "admin"));
    options.AddPolicy("user", policy => policy.RequireClaim("CkApi", "user"));
});

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
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "CK.Produtos.WebAPI", Version = "v1" });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

builder.Services.AddHttpClient();
builder.Services.AddHttpContextAccessor();

//Registrando LOG
builder.Services.AddLogging(config =>
{
    config.AddDebug();
    config.AddConsole();
    config.AddEventLog();
});

builder.Services.AddMvc();

//Desta forma abaixo, restringimos toda a api
//E liberamos somente o que for necessário 
//Não adicionando a anotação Authorize nos metodos da Controller
//builder.Services.AddMvc(config =>
//{
//    var policy = new AuthorizationPolicyBuilder()
//                    .RequireAuthenticatedUser()
//                    .Build();
//    config.Filters.Add(new AuthorizeFilter(policy));
//}).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);


//Adicionando FluentValidation
builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<ProdutoValidator>();

#region DBContextFactory
//services.AddDbContextFactory<EmpresaDbContext>(
//options =>
//options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=BDCK"));
#endregion

builder.Services.UseDbContext<ProdutoDbContext>(builder.Configuration);

//Interface(Domain),  Implementacao (Infra.Data)
//Registrando Scopo (<IEmpresaRepository, EmpresaRepository>)
builder.Services.AddScoped<DBSession>();
builder.Services.AddScoped<IProdutosRepository, ProdutosRepository>();
//builder.Services.AddTransient<IProdutosRepository, ProdutosRepository>();

#region Adicionando Contexto antes de implementar o Extension Method

//services.AddDbContext<EmpresaDbContext>(options =>
//options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

#endregion

//builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline / Configure.

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "CK.Produtos.WebAPI v1");
    });
}

// Habilita o middleware para redicionar as requisições HTTP para HTTPS
app.UseHsts();
app.UseHttpsRedirection();

app.UseRouting();

//app.UseAuthentication();

var corsSettings = builder.Configuration.GetSection("CORSSettings").Value;
app.UseCors(corss => corss
    .WithOrigins(builder.Configuration.GetSection("CORSSettings").GetSection("Origins").Value)
    .WithMethods(builder.Configuration.GetSection("CORSSettings").GetSection("Methods").Value)
    .WithHeaders(builder.Configuration.GetSection("CORSSettings").GetSection("Headers").Value)
.Build());

app.UseAuthorization();
app.UseAuthentication();

app.UseSwagger();
app.UseSwaggerUI();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

//app.ApplyMigrations(WebHostEnvironment);

app.Run();