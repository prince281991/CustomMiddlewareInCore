using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomMiddlewareCoreExample.Middlewares
{
    public class RequestEditingMiddleware
    {
        public RequestDelegate nextDelegate;
        public RequestEditingMiddleware(RequestDelegate next) => nextDelegate = next;
        public async Task Invoke(HttpContext httpContext)
        {
            httpContext.Items["Firefox"] = httpContext.Request.Headers["User-Agent"].Any(x => x.Contains("Firefox"));
            await nextDelegate.Invoke(httpContext);
        }
    }
}
