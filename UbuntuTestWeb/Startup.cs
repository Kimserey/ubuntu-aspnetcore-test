using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace UbuntuTestWeb
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Use((ctx, next) =>
            {
                Console.WriteLine("Before forwarded headers");
                Console.WriteLine("------------------------");
                Print(ctx);
                return next();
            });

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            app.Use((ctx, next) =>
            {
                Console.WriteLine("After forwarded headers");
                Console.WriteLine("-----------------------");
                Print(ctx);
                return next();
            });

            app.UseMvc();
        }

        private void Print(HttpContext context)
        {
            Console.WriteLine("Headers:");
            foreach (var h in context.Request.Headers)
            {
                Console.WriteLine($" - {h.Key}: {h.Value}");
            }
            Console.WriteLine("Host: " + context.Request.Host);
            Console.WriteLine("Path: " + context.Request.Path);
            Console.WriteLine("X-Forwarded-For: " + context.Request.Headers["X-Forwarded-For"]);
            Console.WriteLine("RemoteIpAddress: " + context.Connection.RemoteIpAddress);
            Console.WriteLine("Scheme: " + context.Request.Scheme);
        }
    }
}
