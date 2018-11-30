using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Eindproject2.Models;
using Eindproject2.Models.Data;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Eindproject2.Models.Repositories;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Eindproject2
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
            services.AddMvc(options =>
            {
                options.RespectBrowserAcceptHeader = true;
                options.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());
            })
            .AddJsonOptions(options =>
            {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            })
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddMvc(options =>
            {
                options.RespectBrowserAcceptHeader = true; //false by default 
                options.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());
            });

            services.AddDbContext<Eindproject2APIContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("Eindproject2APIContext")));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1.0", new Info
                {
                    Title = "Eindproject2API",
                    Version =
            "v1  .0"
                });
            });
            
            //Caching Services registreren 
            services.AddHttpCacheHeaders(
                //vervalperiode in seconden 
                (expirationModelOptions) => { expirationModelOptions.MaxAge = 300; },
                //een vervallen response revalideren
                (validationModelOptions) => { validationModelOptions.MustRevalidate = true; }
            );

            services.AddAuthentication("EindprojectScheme").AddCookie("EindprojectScheme", options => {
                options.Events = new CookieAuthenticationEvents()
                {
                    OnRedirectToLogin = (ctx) => {
                        if (ctx.Request.Path.StartsWithSegments("/api") &&
                        ctx.Response.StatusCode == 200) //redirect is 200
                        {
                            //doe geen redirect naar een loginpagina bij een api call                  
                            //maar geef een 401 - unauthorized 
                            ctx.Response.StatusCode = 401;
                        }

                        return Task.CompletedTask;
                    },
                    OnRedirectToAccessDenied = (ctx) =>
                    {
                        if (ctx.Request.Path.StartsWithSegments("/api") &&
                        ctx.Response.StatusCode == 200)
                        {
                            ctx.Response.StatusCode = 403;//uitvoering refused
                        }

                        return Task.CompletedTask;
                    }
                };
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["Tokens:Issuer"],
                        ValidAudience = Configuration["Tokens:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey
                            (Encoding.UTF8.GetBytes(Configuration["Tokens:Key"]))
                    };
                    options.SaveToken = false;
                    options.RequireHttpsMetadata = false;
                });

            services.AddAutoMapper();
            services.AddScoped(typeof(IGenericRepo<>), typeof(GenericRepo<>));
            services.AddScoped<IPlanRepo, PlanRepo>();
            services.AddResponseCaching();
            services.AddCors();
            services.AddIdentity<Users, IdentityRole>()
                .AddEntityFrameworkStores<Eindproject2APIContext>()
                .AddDefaultTokenProviders();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, SeedIdentity seedIdentity)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors(cfg => { cfg.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin(); });

            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "swagger"; //kan je dus aanpassen naar een ander uri      
                c.SwaggerEndpoint("/swagger/v1.0/swagger.json", "Eindproject2API v1.0");
            });
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseHttpCacheHeaders();
            app.UseMvc();
            app.UseSwagger();
            app.UseResponseCaching();
            seedIdentity.SeedIdentityEindproject2API().Wait();
        }
    }
}
