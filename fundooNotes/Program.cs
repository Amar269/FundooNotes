
using BusinessLogicLayer.Interface;
using BusinessLogicLayer.Service;
using DataBaseLayer.Context;
using DataBaseLayer.Interface;
using DataBaseLayer.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using StackExchange.Redis;
namespace fundooNotes
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],

            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            //builder.Services.AddSwaggerGen(); ----------------- orginal code -------- updated down below to add JWT Authentication in Swagger UI

            builder.Services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("Bearer",
                    new OpenApiSecurityScheme
                    {
                        Name = "Authorization",
                        Type = SecuritySchemeType.Http,
                        Scheme = "bearer",
                        BearerFormat = "JWT",
                        In = ParameterLocation.Header,
                        Description = "Enter JWT Token"
                    });

                options.AddSecurityRequirement(
                    new OpenApiSecurityRequirement
                    {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                Array.Empty<string>()
            }
                    });
            });


            builder.Services.AddDbContext<UserDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("FundooNotesDB")));

            builder.Services.AddScoped<IUserDAL,UserDAL>();

            builder.Services.AddScoped<IUserBLL, UserBLL>();

            builder.Services.AddScoped<IEmailService, EmailService>();

            builder.Services.AddScoped<INoteDAL, NoteDAL>();

            builder.Services.AddScoped<INoteBLL, NoteBLL>();

            builder.Services.AddScoped<ILabelDAL, LabelDAL>();

            builder.Services.AddScoped<ILabelBLL, LabelBLL>();

            builder.Services.AddScoped<IRedisDAL, RedisDAL>();

            builder.Services.AddScoped<IRedisBLL , RedisBLL>();

            builder.Services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration =
                    builder.Configuration["Redis:ConnectionString"];
            });

            builder.Services.AddSingleton<IConnectionMultiplexer>(
                ConnectionMultiplexer.Connect(
                    builder.Configuration["Redis:ConnectionString"])
            );

            




            var app = builder.Build();

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
}
