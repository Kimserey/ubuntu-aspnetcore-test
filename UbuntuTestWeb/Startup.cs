using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.DependencyInjection;
using System;

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
                Console.WriteLine("Host: " + ctx.Request.Host);
                Console.WriteLine("Path: " + ctx.Request.Path);
                Console.WriteLine("For: " + ctx.Connection.RemoteIpAddress);
                Console.WriteLine("Scheme: " + ctx.Request.Scheme);
                return next();
            });

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            app.Use((ctx, next) =>
            {
                Console.WriteLine("After forwarded headers");
                Console.WriteLine("Host: " + ctx.Request.Host);
                Console.WriteLine("Path: " + ctx.Request.Path);
                Console.WriteLine("For: " + ctx.Connection.RemoteIpAddress);
                Console.WriteLine("Scheme: " + ctx.Request.Scheme);
                return next();
            });

            app.UseMvc();
        }
    }
}
