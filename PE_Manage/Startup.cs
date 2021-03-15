using IRepository;
using IService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Repository;
using Service;
using SqlSugar.IOC;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PE_Manage
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

            #region  SwaggerIOC
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("V1", new OpenApiInfo
                {
                    Title="体检管理系统",
                    Version="V1"
                });
            });
            #endregion

            #region SqlSugar
            services.AddSqlSugar(new IocConfig()
            {
                ConnectionString = this.Configuration["SqlConn"],
                DbType = IocDbType.SqlServer,
                IsAutoCloseConnection = true//自动释放
            }); ;
            #endregion

            #region  IOC依赖注入
            services.AddPE_ManageIOC();
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            #region Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/V1/swagger.json", "PE_Manage");
                c.RoutePrefix = string.Empty;
            });
            #endregion

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

    //IOC依赖注入比较多，所以来一个类
    static class IOCExtend
    {
        public static IServiceCollection AddPE_ManageIOC(this IServiceCollection service)
        {
            service.AddScoped<IPeCustomerRepository, PeCustomerRepository>();
            service.AddScoped<IPeCustomerService, PeCustomerService>();
            return service;
        }
    }
}
