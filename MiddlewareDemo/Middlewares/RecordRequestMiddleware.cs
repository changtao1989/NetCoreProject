using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddlewareDemo.Middlewares
{
    public class RecordRequestMiddleware
    {
        private RequestDelegate _next;
        private ILogger<RecordRequestMiddleware> _logger;

        public RecordRequestMiddleware(RequestDelegate next,ILogger<RecordRequestMiddleware> logger)
        {
            this._next = next;
            this._logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            if(context.Request.Method == HttpMethods.Post)
            {
                var request = context.Request;
                var buffer=new byte[Convert.ToInt32(request.ContentLength)];
                await request.Body.ReadAsync(buffer, 0, buffer.Length);
                var bodyString = Encoding.UTF8.GetString(buffer);
                this._logger.LogInformation($"Protocal:{request.Protocol},Host:{request.Host},Path:{request.Path}");
                await this._next(context);
            }
        }
    }
}
