using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using PkmnApi.Models;
namespace PkmnApi
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
             services.AddDbContextPool<PkmnContext>(opt =>
                                                 opt.UseSqlServer(Configuration.GetConnectionString("pkmnDbConnection")));
             services.AddDbContextPool<MoveContext>(opt =>
                                                 opt.UseSqlServer(Configuration.GetConnectionString("pkmnDbConnection")));
             services.AddDbContextPool<AbilityContext>(opt =>
                                                 opt.UseSqlServer(Configuration.GetConnectionString("pkmnDbConnection")));
            // services.AddDbContext<PkmnContext>(opt =>
            //                                    opt.UseInMemoryDatabase("pkmnDb"));
            // services.AddDbContext<AbilityContext>(opt =>
            //                                    opt.UseInMemoryDatabase("pkmnDb"));
            // services.AddDbContext<MoveContext>(opt =>
            //                                    opt.UseInMemoryDatabase("pkmnDb"));
            services.AddControllers();
            // services.AddSwaggerGen(c =>
            // {
            //     c.SwaggerDoc("v1", new OpenApiInfo { Title = "PkmnApi", Version = "v1" });
            // });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                // app.UseSwagger();
                // app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PkmnApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
