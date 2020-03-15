using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomMiddlewareCoreExample.Middlewares
{
    public class ContentMiddleware
    {
        public RequestDelegate nextDelegate;
        public ContentMiddleware(RequestDelegate next) => nextDelegate = next;
        public async Task Invoke(HttpContext httpContext)
        {
            if(httpContext.Request.Path.ToString()=="/middleware")
            {
                await httpContext.Response.WriteAsync("this is from the Content Middleware");
            }
            else
            {
                await nextDelegate.Invoke(httpContext);
                
            }
        }
    }
}
