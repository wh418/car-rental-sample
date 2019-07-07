using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRental.Common.Filters;
using CarRental.Core.Config;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Swagger;

namespace CarRental.Api
{
    public class Startup
    {
        private const string CorsPolicy = "CarRental.Api.Cors.Policy";
        private IConfiguration Configuration { get; }
        private IHostingEnvironment Environment { get; }

        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            Environment = env;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddWebEncoders()
                .AddResponseCompression()
                .AddCors(options => options.AddPolicy(CorsPolicy, builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials()))
                .AddMvcCore(o =>
                {
                    o.Filters.Add<HandleResponseFilter>();
                    o.Filters.Add<UnhandledExceptionFilter>();
                })
                .AddApiExplorer()
                .AddJsonFormatters(settings =>
                {
                    settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    settings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
                    settings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
                    settings.Converters.Add(new StringEnumConverter());
                    settings.NullValueHandling = NullValueHandling.Ignore;
                }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services
                .AddOptions()
                .ConfigureCoreBindings(Configuration);
            if (!Environment.IsProduction())
            {
                services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new Info { Title = "CarRental.Api", Version = "v1" });
                });
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseForwardedHeaders();
                app.UseHsts();
                //app.UseHttpsRedirection();
            }

            app.UseCors(CorsPolicy);
            app.UseResponseCompression();
            app.UseMvc();

            if (!env.IsProduction())
            {
                app.UseSwagger();
                app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1/swagger.json", "Api"));
            }
        }
    }
}
