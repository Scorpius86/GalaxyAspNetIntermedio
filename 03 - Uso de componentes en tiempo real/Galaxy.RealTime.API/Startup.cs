using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Galaxy.RealTime.API.Data;
using Galaxy.RealTime.API.Models;
using Galaxy.RealTime.API.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Galaxy.RealTime.API
{
    public class Startup
    {
        readonly string AllowAPIOrigins = "_allowAPIOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(AllowAPIOrigins,
                builder =>
                {
                    builder.WithOrigins("http://localhost:44330")
                     .AllowAnyHeader()
                     .AllowAnyMethod();
                });
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            string conStr = Configuration["connectionStrings:libraryConnectionString"];
            services.AddDbContext<LibraryContext>(opt => opt.UseSqlServer(conStr));
            services.AddScoped<ILibraryRepository, LibraryRepository>();
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Author, AuthorDto>();
                cfg.CreateMap<AuthorDto, Author>();
                cfg.CreateMap<Book, BookDto>();
            });

            app.UseCors(AllowAPIOrigins);
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
