using System;
using API.Middleware;
using Microsoft.AspNetCore.Builder;

namespace API.Helpers
{
    public static class AppExtensions
    {
        public static IApplicationBuilder EnsureCreated(this IApplicationBuilder app){
            return app.UseMiddleware<SeedDataMiddleware>();
        }
    }
}
