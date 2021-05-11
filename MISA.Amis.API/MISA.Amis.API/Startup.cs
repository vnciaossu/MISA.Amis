using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MISA.Amis.API.Middleware;
using MISA.BL.Interfaces.Repository;
using MISA.BL.Interfaces.Services;
using MISA.BL.Services;
using MISA.DL.Repository;

namespace MISA.Amis.API
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
            services.AddCors(opts => opts.AddPolicy("My Policy", policy => policy.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin()));
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MISA.Amis.API", Version = "v1" });
            });
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IEmployeeService, EmployeeService>();

            services.AddScoped<IEmployeeDepartmentService, EmployeeDepartmentService>();
            services.AddScoped<IEmployeeDepartmentRepository, EmployeeDepartmentRepository>();

            services.AddScoped<IEmployeePositionService, EmployeePositionService>();
            services.AddScoped<IEmployeePositionRepository, EmployeePositionRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MISA.Amis.API v1"));
            }

            app.UseCors("My Policy");

            app.UseMiddleware<ErrorExceptionHandling>();

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