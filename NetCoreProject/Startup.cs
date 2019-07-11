using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetCoreProject.Models;

namespace NetCoreProject
{
    public class Startup
    {
        private IConfiguration Configuration;
       
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            //从Configs读取config.json文件的内容,绑定对象Person
            Person p = new Person();
            this.Configuration.Bind("Person", p);
            //将Person对象注入到IOC容器中
            services.AddSingleton<Person>(p);

            //配置热更新
            services.Configure<Person>(Configuration.GetSection("Person"));

            //在ASP.NET Core2.2中使用最新路由方案，需要为MVC服务注册指定兼容性版本
            services.AddMvc()
                    .SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_2_2);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            //在launchSettings.json里配置了环境变量，可以通过IsEnvironment方法调用
            if (env.IsEnvironment("UAT"))
            {

            }

            //默认路由模板
            app.UseMvc(routes => 
            {
                routes.MapRoute(
                    name:"default",
                    template:"{controller}/{action}/{id?}"
                    );
            });
        }
    }
}
