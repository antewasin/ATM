using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATM.Core.IRepository;
using ATM.Frameworks;
using ATM.Infrastructure.EF;
using ATM.Infrastructure.Filters;
using ATM.Infrastructure.Repository;
using ATM.Infrastructure.Settings;
using ATM.Services;
using ATM.Services.Mapper;
using ATM.Services.Transaction;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ATM
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
                options.Filters.Add(typeof(ExceptionHandlerAttribute));
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddMemoryCache();

            services.Configure<AppSettings>(Configuration.GetSection("app"));

            services.AddDbContext<ATMContext>(options
                => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("ATM")));

            services.AddScoped<IATMService, ATMService>();
            services.AddScoped<IATMRepository, ATMRepository>();

            services.AddScoped<ICardService, CardService>();
            services.AddScoped<ICardRepository, CardRepository>();

            services.AddScoped<ITransactionService, TransactionService>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();

            services.AddSingleton(AutoMapperConfig.Initialize());


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //app.UseExceptionHandler("/error");
                app.UseHsts();
            }
            app.UseStaticFiles();
            app.UseDefaultFiles();
            app.UseMiddleware<RequestLogMiddleware>();

            app.UseHttpsRedirection();
            app.UseMvc();

           

        }
    }
}
