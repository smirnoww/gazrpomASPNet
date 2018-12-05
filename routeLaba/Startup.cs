﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Routing;

namespace routeLaba
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            var routeBuilder = new RouteBuilder(app);

            routeBuilder.MapRoute("{lastname}/{firstname}", Handle);
            app.UseRouter(routeBuilder.Build());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                // Q : Как программно задать кодировку один раз при инициализации приложения?
                // A : 
                context.Response.ContentType = "text/html; charset=utf-8";
                await context.Response.WriteAsync("Напишите в адресной строке domen:port/фамилия/имя и мы их склеим");
            });
        }

        private async Task Handle(HttpContext context)
        {
            var routeValues = context.GetRouteData().Values;

            var lastname = routeValues["lastname"].ToString();
            var firstname = routeValues["firstname"].ToString();

            var result = lastname + " " + firstname;

            context.Response.ContentType = "text/html; charset=utf-8";
            await context.Response.WriteAsync("Склеили: " + result);
        }

    }
}
