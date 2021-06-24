using LojaQualquer.WebApi.Configuration;
using LojaQualquer.WebApi.Domain.Models;
using LojaQualquer.WebApi.Repository.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace LojaQualquer.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var authorizeConfig = new AuthorizeConfig();
            new ConfigureFromConfigurationOptions<AuthorizeConfig>(Configuration.GetSection("AuthorizeConfig")).Configure(authorizeConfig);
            services.AddSingleton(authorizeConfig);

            services.AddAuthentication(x =>
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
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(authorizeConfig.Key)),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = authorizeConfig.Audience,
                    ValidIssuer =  authorizeConfig.Issuer
                };
            });

            services.AddControllers(c => c.Filters.Add(new HttpResponseExceptionFilter()));

            services.AddDbContext<EntityContext>(o =>
                o.UseLazyLoadingProxies().UseSqlServer(Configuration.GetConnectionString("Default")));

            services.ConfigureService();
            services.ConfigureRepository();

            services.AddAutoMapper(typeof(Startup));

            var xmlPath = Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml");

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "LojaQualquer.WebApi", Version = "v1" });

                
                c.IncludeXmlComments(xmlPath);
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSwagger();

            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "LojaQualquer.WebApi v1"));

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
