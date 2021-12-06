using System.Text;
using HBS.Domain.IRepositories;
using HBS.Domain.Services;
using HBS.HairBySilke_2021.Core.IServices;
using HBS.HairBySilke_2021.DataAccess;
using HBS.HairBySilke_2021.DataAccess.Repositories;
using HBS.HairBySilke_2021.Security;
using HBS.HairBySilke_2021.Security.Entities;
using HBS.HairBySilke_2021.Security.IRepositories;
using HBS.HairBySilke_2021.Security.IServices;
using HBS.HairBySilke_2021.Security.Repositories;
using HBS.HairBySilke_2021.Security.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace HBS.HariBySilke_2021.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo {Title = "HBS.HariBySilke_2021.WebApi", Version = "v1"});
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'bearer [space] and then your token in the text input below \r\n\r\n Example: 'Bearer 12345abcdef' "
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
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
                    new string[]{}
                    }
                });
            });
            

            services.AddAuthentication(authenticationOptions =>
            {
                authenticationOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authenticationOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = 
                            new SymmetricSecurityKey(
                                Encoding.UTF8.GetBytes(Configuration["Jwt:Secret"])),
                        ValidateIssuer = true,
                        ValidIssuer = Configuration["Jwt:Issuer"],
                        ValidateAudience = true,
                        ValidAudience = Configuration["Jwt:Audience"],
                        ValidateLifetime = true
                    };
                });
                
            services.AddScoped<ITreatmentsRepository, TreatmentRepository>();
            services.AddScoped<ITreatmentsService, TreatmentsService>();
            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<IBookingService, BookingService>();
            services.AddScoped<ITimeSlotRepository, TimeSlotRepository>();
            services.AddScoped<ITimeSlotService, TimeSlotService>();
            
            services.AddScoped<IAuthUserRepository, AuthUserRepository>();
            services.AddScoped<IAuthUserService, AuthUserService>();
            services.AddScoped<ISecurityService, SecurityService>();

            services.AddDbContext<MainDbContext>(opt =>
            {
                opt.UseSqlite("Data Source=main.db");
            });
            
            services.AddDbContext<AuthDbContext>(opt =>
            {
                opt.UseSqlite("Data Source=auth.db");
            });
            
            
            
            services.AddCors(options =>
            {
                options.AddPolicy("Dev-cors", policy =>

                {
                    policy
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();

                });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
            MainDbContext ctx,
            AuthDbContext authCtx)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HBS.HariBySilke_2021.WebApi v1"));

                app.UseCors("Dev-cors");
                
                new DbSeeder(ctx).SeedDevelopment();
                new AuthDbSeeder(authCtx).SeedDevelopment();
            }
            else
            {
                new DbSeeder(ctx).SeedProduction();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}