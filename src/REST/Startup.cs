using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using FluentValidation.AspNetCore;
using Models;
using DataLayer;

namespace REST
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
            services.AddControllers();

            services.AddDbContext<PXDBContext>(opts => opts.UseNpgsql(Configuration.GetConnectionString("PXDB")));

            services.AddSingleton(_ => Configuration);

            services.AddFluentValidation(cfg =>
            {
                cfg.DisableDataAnnotationsValidation = true;
                cfg.RegisterValidatorsFromAssemblyContaining<Startup>();
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Client_Portal", Version = "v1" });
            });

            services.AddCors(
                (options) =>
                {
                    options.AddPolicy(name: "_myAllowSpecificOrigins",
                        builder =>
                        {
                            builder.WithOrigins("http://localhost:4200/")
                            .AllowAnyHeader()
                            .WithMethods("GET", "POST", "PUT", "DELETE")
                            .WithExposedHeaders("*");
                        });
                }
            );
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            Stripe.StripeConfiguration.ApiKey = "sk_test_51JPsbPLwtPYhS8YtUvEDttDcmfwwcdglHCSs9nyfNJIbgVdzY1HVeTDUOefYYbiUBiaQM1zwWOj1vHqHFYPwjFtV00nuyv4l8A";

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Client_Portal v1"));
            }


            if (env.IsDevelopment())
            {
                app.UseHttpsRedirection();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
