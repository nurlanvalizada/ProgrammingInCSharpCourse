using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Lesson30_WebApi.Configurations;
using Lesson30_WebApi.Data;
using Lesson30_WebApi.Models;
using Lesson30_WebApi.Repository;
using Lesson30_WebApi.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace Lesson30_WebApi
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
            services.AddControllers().AddFluentValidation();

            services.AddTransient<IValidator<StudentModel>, StudentValidator>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Lesson30_33_WebApi", Version = "v1" });
            });

            services.AddSingleton<IUser, User>();

            services.AddSingleton<ISingletonOperation, Operation>();
            services.AddTransient<ITransientOperation, Operation>();
            services.AddScoped<IScopedOperation, Operation>();

            services.AddDbContext<StudentDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("Default")));

            services.AddTransient<IStudentRepository, StudentRepository>();
            services.AddTransient(typeof(IRepository<,>), typeof(EfRepository<,>));
            services.AddTransient<IUnitOfWork, UnitOfWork.UnitOfWork>();

            services.Configure<PositionOptions>(Configuration.GetSection(PositionOptions.Position));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Lesson30_33_WebApi v1"));
            }

            app.UseStaticFiles();

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
