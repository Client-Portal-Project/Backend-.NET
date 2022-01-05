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
using REST.DataLayer;
using Microsoft.OpenApi.Models;
using REST.BusinessLayer;
using FluentValidation.AspNetCore;

namespace REST
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

            services.AddScoped<IApplicantBL, ApplicantBL>();
            services.AddScoped<IApplicantRepo, ApplicantRepo>();
            services.AddScoped<IApplicantOccupationRepo, ApplicantOccupationRepo>();
            services.AddScoped<IApplicantSkillRepo, ApplicantSkillRepo>();
            
            //services.AddScoped<IOccupationRepo, OccupationRepo>();
            services.AddScoped<IClientRepo, ClientRepo>();
            services.AddScoped<INeedRepo, NeedRepo>();
            //services.AddScoped<ITopicRepo, TopicRepo>();
            //services.AddScoped<IOrderRepo, OrderRepo>();
            //services.AddScoped<IUserRepo, UserRepo>();

            //services.AddScoped<IOccupationBL, OccupationBL>();
            //services.AddScoped<IOrderBL, OrderBL>();
            //services.AddScoped<ITopicBL, TopicBL>();
            //services.AddScoped<IUserBL, UserBL>();


            //services.AddDbContext<BatchesDBContext>(opt => opt.UseInMemoryDatabase(databaseName: "TestDatabase"));

            // TODO use when psql database is good to use
            services.AddDbContext<BatchesDBContext>(opts => opts.UseNpgsql(Configuration.GetConnectionString("batchesDB")));

            services.AddSingleton(_ => Configuration);

            // services.AddScoped<IOccupationRepo, OccupationRepo>();
            // services.AddScoped<IOrderRepo, OrderRepo>();

            services.AddFluentValidation(cfg => 
            {
                cfg.DisableDataAnnotationsValidation = true;
                cfg.RegisterValidatorsFromAssemblyContaining<Startup>();
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Client_Portal", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            Stripe.StripeConfiguration.ApiKey = "sk_test_51JPsbPLwtPYhS8YtUvEDttDcmfwwcdglHCSs9nyfNJIbgVdzY1HVeTDUOefYYbiUBiaQM1zwWOj1vHqHFYPwjFtV00nuyv4l8A";

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Client_Portal v1"));
            }

            // TODO: for security, make sure this is more defined later on
            app.UseCors(opts => opts.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            if (env.IsDevelopment()){
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
