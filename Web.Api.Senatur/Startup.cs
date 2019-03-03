using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;
using System;

namespace Web.Api.Senatur {
    public class Startup {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services) {
            //Adciona oções do json e mvc
            services.AddMvc().AddJsonOptions(options => {
                options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;//ignora valores nulos
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;//ignora loop de referencia
                }
            ).SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_2_1);//seta compatibilidade com a versão 2.1 do aspnetcore

            services.AddAuthentication();//adciona autenticação

            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new Info { Title = "Senatur", Version = "v1" });
            });

            services.AddAuthentication(
                item => {
                    item.DefaultAuthenticateScheme = "JwtBearer";
                    item.DefaultChallengeScheme = "JwtBearer";
                }
            ).AddJwtBearer(
              "JwtBearer", x => {
                  x.TokenValidationParameters = new TokenValidationParameters() {
                      ValidateIssuer = true,
                      ValidIssuer = "Senatur.WebApi",

                      ValidateAudience = true,
                      ValidAudience = "Senatur.WebApi",

                      ValidateLifetime = true,
                      ClockSkew = TimeSpan.FromMinutes(30),

                      IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("Chave-Autenticacao-Senatur"))
                  };
              }
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Senatur ");
            });

            app.UseAuthentication();

            app.UseMvc();
        }
    }
}
