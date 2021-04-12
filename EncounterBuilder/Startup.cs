using AutoMapper;
using ElectronNET.API;
using EncounterBuilder.BusinessRules.Clients;
using EncounterBuilder.BusinessRules.Contracts;
using EncounterBuilder.BusinessRules.Profiles;
using EncounterBuilder.DAC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

namespace EncounterBuilder
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddEntityFrameworkSqlite().AddDbContext<EncounterBuilderDbContext>(options =>
            {
                options.UseSqlServer(Configuration["Global:ConnectionStrings:ENCOUNTERX"]);
                
                options.EnableSensitiveDataLogging(true);
            });

            services.AddScoped<ICharacterRepository, CharacterData>();
            services.AddScoped<DAC.Contract.ICharacterRepository, DAC.Client.CharacterData>();

            services.AddRazorPages();
            
            services.AddSingleton(new MapperConfiguration(mc =>
            {
                mc.AddProfile(new CharacterProfiles());

            }).CreateMapper());
            services.AddServerSideBlazor();

            services.Configure<KestrelServerOptions>(Configuration.GetSection("Kestral"));

            services.AddCors(options =>
            {
                CorsPolicyBuilder builder = new CorsPolicyBuilder();
                builder.AllowAnyOrigin();
                builder.AllowAnyMethod();
                builder.AllowAnyHeader();
                //TODO: Figure out if needed
                //builder.AllowCredentials();
                options.AddDefaultPolicy(builder.Build());
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });

            //Task.Run(async () => await Electron.WindowManager.CreateWindowAsync());
        }
    }
}
