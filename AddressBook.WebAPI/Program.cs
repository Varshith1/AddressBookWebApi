using AddressBook.WebAPI;
using AddressBookServices.Interfaces;
using AddressBookServices.Services;
using AddressBookWebAPI.Repository.Dapper;
using AddressBookWebAPI.Repository.EfRepo;
using AddressBookWebAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using Swashbuckle.AspNetCore.Filters;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        //builder.Services.AddScoped<DapperContext>();

        builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
        /*
        builder.Services.AddScoped<IAddressBookRepository, AddressBookEfRepository>();
        //builder.Services.AddScoped<IAddressBookRepository, AddressBookDapperRepository>();
        builder.Services.AddScoped<IAddressBookWebApiServices, AddressBookWebApiServices>();
        builder.Services.AddScoped<IAuthentificatinServices, AuthentificatinServices>();
        //builder.Services.AddScoped<IAuthenticationRepository,AuthenticationRepository>();
        builder.Services.AddScoped<IAuthenticationRepository, AuthenticationEfCore>();*/
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();

        var container = new Container();
        container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
        container.RegisterPackages(new[] { typeof(Registrations).Assembly });
      

        builder.Services.AddSimpleInjector(container, options =>
        {
            options.AddAspNetCore().AddControllerActivation().AddViewComponentActivation();
        });

        builder.Services.AddAutoMapper(typeof(AutoMapper.Configuration.Mapper.Mapper));

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    
        builder.Services.AddCors(path =>
        {
            path.AddPolicy("MyAllowSpecificOrigins",
            builder =>
            {
                builder.WithOrigins("http://127.0.0.1:5500")
             .AllowAnyHeader()
             .AllowAnyMethod();
            });
        });
        builder.Services.AddHttpContextAccessor();
        builder.Services.AddSwaggerGen(options =>
        {
            options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
            {
                Description = "Standard Authorization header using the Bearer scheme (\"bearer {token}\")",
                In = ParameterLocation.Header,
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey
            }); options.OperationFilter<SecurityRequirementsOperationFilter>();
        });
        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8
             .GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)),
                ValidateIssuer = false,
                ValidateAudience = false
            };
        });
        var MyAllowSpecificOrigins = "_myAllowSpecificOrigins"; builder.Services.AddCors(options =>
        {
            options.AddPolicy(name: MyAllowSpecificOrigins,
            policy =>
            {
                policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
            });
        });
        builder.Services.AddMvc();

        var app = builder.Build();
        app.Services.UseSimpleInjector(container);
        app.UseCors("MyAllowSpecificOrigins");

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthentication();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}