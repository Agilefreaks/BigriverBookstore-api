using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using JsonApiDotNetCore.Extensions;
using JsonApiDotNetCore.Services;
using BigriverBookstore_api.Data;
using BigriverBookstore_api.Services;
using BigriverBookstore_api.Resources;
using AutoMapper;
using Swashbuckle.AspNetCore.Swagger;

namespace BigriverBookstore_api
{
    public class Startup
    {
        public IRepositoryWrapper _wrapper;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public virtual IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            var mvcCoreBuilder = services.AddMvcCore();
            services.AddJsonApi(
                options => options.Namespace = "api",
                mvcCoreBuilder,
                discover => discover.AddCurrentAssembly());

            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            services.AddScoped<IResourceService<Book>, BookResourceService>();
            services.AddScoped<IResourceService<Author>, AuthorResourceService>();
            services.AddAutoMapper(typeof(Startup));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = "BigriverBookstore_api",
                    Version = "v1"
                });
            });

            return services.BuildServiceProvider();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public virtual void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseJsonApi();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "BigriverBookstore_api");
            });
        }
    }
}
