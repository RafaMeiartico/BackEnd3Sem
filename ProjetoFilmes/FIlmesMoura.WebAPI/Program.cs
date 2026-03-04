using FIlmesMoura.WebAPI.BdContextFilme;
using FIlmesMoura.WebAPI.Interface;
using FIlmesMoura.WebAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;

var builder = WebApplication.CreateBuilder(args);

//Adicionar o contexto do banco de dados (Exemplo com SQL
builder.Services.AddDbContext<FilmeContext>
    (options => options.UseSqlServer
    (builder.Configuration.GetConnectionString
    ("DefaultConnection")));

//Adiciona o repositorio ao container de injeção de dependencia
builder.Services.AddScoped<IFilmeRepository, FilmeRepository>();
builder.Services.AddScoped<IGeneroRepository, GeneroRepositorio>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

//Adiciona serviço de Jwt Bearer (forma de autenticação)
builder.Services.AddAuthentication(options =>
{
    options.DefaultChallengeScheme = "JwtBearer";
    options.DefaultAuthenticateScheme = "JwtBearer";
})

    .AddJwtBearer("JwtBearer", options =>
    {
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            //valida quem está solicitando
            ValidateIssuer = true,

            //valida quem está recebendo 
            ValidateAudience = true,

            //define se o tempo de expiração será validado
            ValidateLifetime = true,

            //forma de criptografia e valida a chave de autenticação
            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("filmes-chave-autenticacao-webapi-dev")),

            //valida o tempo de expiração do token
            ClockSkew = TimeSpan.FromMinutes(5),

            //nome do issuer (de onde está vindo)
            ValidIssuer = "api-filmes",

            //nome do audience (para onde está indo)
            ValidAudience = "api_filmes",

        };
    });

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("vl", new Microsoft.OpenApi.OpenApiInfo
    {
        Version = "vl",
        Title = "Filmes API",
        Description = "Uma API com uma catálogo de filmes", 
        TermsOfService = new Uri("https://examplo/com/terms"),
        Contact = new Microsoft.OpenApi.OpenApiContact
        { 
            Name = "marcaumdev",
            Url = new Uri("https://example/com/license")
        },
        License = new Microsoft.OpenApi.OpenApiLicense
        { 
            Name = "Example License",
            Url = new Uri("https://example.com/licenses")
        }

    });

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Autorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Insira o token JWT"
    });

    options.AddSecurityRequirement(document => new OpenApiSecurityRequirement
    {
        [new OpenApiSecuritySchemeReference("Bearer", document)] = Array.Empty<string>().ToList()
    });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

//adiciona serviço de controlles

builder.Services.AddControllers();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger(options => { });

    app.UseSwaggerUI(options => 
    {
        options.SwaggerEndpoint("/swagger/vl/swagger.json", "vl");
        options.RoutePrefix = string.Empty;
    });
}

app.UseCors("CorsPolicy");

app.UseStaticFiles();   

app.UseAuthentication();

app.UseAuthorization();

//adiciona o mapeamento de controllers
app.MapControllers();

app.Run();
