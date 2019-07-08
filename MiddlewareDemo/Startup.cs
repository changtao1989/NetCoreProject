using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MiddlewareDemo.Middlewares;

namespace MiddlewareDemo
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStatusCodePages();
            //中间件1
            app.Use(async (context, next) =>
            {
                //第一步
                //await context.Response.WriteAsync("Middleware1 start\r\n");
                logger.LogInformation("Middleware1 start\r\n");
                //调用下一个中间件
                await next();
                //第五步
                //await context.Response.WriteAsync("Middleware1 end\r\n");
                logger.LogInformation("Middleware1 end\r\n");
            });

            //自定义中间件
            app.UseMiddleware<RecordRequestMiddleware>();
            //app.UserRequestCulture();

            #region 中间件
            ////中间件1
            //app.Use(async (context, next) =>
            //{
            //    //第一步
            //    await context.Response.WriteAsync("Middleware1 start\r\n");
            //    //调用下一个中间件
            //    await next();
            //    //第五步
            //    await context.Response.WriteAsync("Middleware1 end\r\n");
            //});

            ////中间件2
            //app.Use(async (context, next) =>
            //{
            //    //第二步
            //    await context.Response.WriteAsync("Middleware2 start\r\n");
            //    //调用下一个中间件
            //    await next();
            //    //第四步
            //    await context.Response.WriteAsync("Middleware2 end\r\n");
            //});

            ////中间件3
            //app.Map("/middleware", config =>
            //{
            //    config.Use(async (context, next) =>
            //    {
            //        await context.Response.WriteAsync("Middleware3 start \r\n");
            //        await next();
            //        await context.Response.WriteAsync("Middleware3 stop \r\n");
            //    });
            //});

            ////中间件终端
            //app.Run(async (context) =>
            //{
            //    //第三步
            //    await context.Response.WriteAsync("Hello World!\r\n");
            //});
            #endregion


            //MVC中间件
            app.UseMvcWithDefaultRoute();
        }
    }
}
