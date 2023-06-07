using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ASPBlog.Api.Core;
using ASPBlog.Api.Emails;
using ASPBlog.Api.Extensions;
using ASPBlog.Application.Emails;
using ASPBlog.Application.Logging;
using ASPBlog.Application.UseCases;
using ASPBlog.Implementation;
using ASPBlog.Implementation.Emails;
using System;
using System.IO;
using System.Reflection;
using Abp.Net.Mail.Smtp;
using ProjekatASP.Api.Core;

namespace ASPBlog.Api
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
            var settings = new AppSettings();
            Configuration.Bind(settings);

            services.AddSingleton(settings);
            services.AddAppUser();
            services.AddJwt(settings);
            services.AddASPBlogDbContext();
            services.AddUseCases();
            services.AddTransient<IExceptionLogger, ConsoleExceptionLogger>();
            services.AddTransient<IUseCaseLogger, ConsoleUseCaseLogger>();
            services.AddTransient<UseCaseHandler>();
            services.AddTransient<IEmailSender>(x =>
            new SmtpEmailSender(settings.EmailOptions.FromEmail,
                                settings.EmailOptions.Password,
                                settings.EmailOptions.Port,
                                settings.EmailOptions.Host));
            services.AddControllers();
            services.AddHttpContextAccessor();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ASPBlog.Api", Version = "v1" });

                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProjekatASP v1"));
            }

            app.UseRouting();
            app.UseMiddleware<GlobalExceptionHandler>();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
