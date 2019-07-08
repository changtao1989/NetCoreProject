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
            #region 状态码中间件
            //状态码中间件(如果访问的页面不存在的话,返回404状态码)
            //app.UseStatusCodePages("text/html","<h1>statuscode:{0}</h1>"); 
            //如果访问的页面不存在,则跳转到StatusCodePagesWithRedirects(先返回302，再去请求返回200)
            //app.UseStatusCodePagesWithRedirects("/ErrorPages/{0}");
            //如果访问的页面不存在,则跳转到/Home/ErrorPage(直接返回404状态码加页面)
            app.UseStatusCodePagesWithReExecute("/Home/ErrorPage","?code={0}");
            #endregion


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

            app.Map("/middleware", builder => 
            {
                builder.Run(async (context) =>
                {
                    await context.Response.WriteAsync("我是中间件终端(middleware)");
                });
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
