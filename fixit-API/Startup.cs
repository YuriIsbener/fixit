using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;

namespace fixit_API
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            // using System.Net;

            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.KnownProxies.Add(IPAddress.Parse("127.0.0.1"));
            });

            // Adiciona o serviço dos Controllers
            services
                .AddControllers()
                .AddNewtonsoftJson(options =>
                {
                // Ignora os loopings nas consultas
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                // Ignora valores nulos ao fazer junções nas consultas
                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                });

            // Adiciona o serviço do Swagger
            // https://docs.microsoft.com/pt-br/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-5.0&tabs=visual-studio

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Fix.It.webApi", Version = "v1" });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
            services
              // Define a forma de autenticação
              .AddAuthentication(options =>
              {
                  options.DefaultAuthenticateScheme = "JwtBearer";
                  options.DefaultChallengeScheme = "JwtBearer";
              })

              // Define os parâmetros de validação do token
              .AddJwtBearer("JwtBearer", options =>
              {
                  options.TokenValidationParameters = new TokenValidationParameters
                  {
                      // Quem está solicitando
                      ValidateIssuer = true,

                      // Quem está validando
                      ValidateAudience = true,

                      // Definindo se tempo de expiração será validado
                      ValidateLifetime = true,

                      // Forma de criptografia
                      IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("Fix.It-chave-autenticacao")),

                      // Tempo de expiração do token
                      ClockSkew = TimeSpan.FromMinutes(30),

                      // Nome da issuer, de onde está vindo
                      ValidIssuer = "FixIt.Api",

                      // Nome da audience, de onde está vindo
                      ValidAudience = "FixIt.Api"
                  };
              });
        }
    

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            app.UseSwagger();

            app.UseSwaggerUI(c => {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Fix.It.webApi");
            c.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                // Define o mapeamento dos Controllers
                endpoints.MapControllers();
            });
        }
    }
}
