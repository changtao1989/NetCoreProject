using Microsoft.AspNetCore.Builder;
using MiddlewareDemo.Middlewares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiddlewareDemo
{
    public static class RequestCultureMiddlewareExtensions
    {
        public static IApplicationBuilder UserRequestCulture(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RecordRequestMiddleware>();
        }
    }
}
