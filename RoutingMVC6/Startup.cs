using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Action = Microsoft.Azure.KeyVault.Models.Action;

namespace RoutingMVC6
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddMvcCore().AddViews();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
            //app.UseMvcWithDefaultRoute();
            app.UseMvc(ConfigureRoutes);
        }

        private void ConfigureRoutes(IRouteBuilder route)
        {
            //id is Custom Url Segment, with default value as "Defaultvalue"
            route.MapRoute(name: "FirstRoute", template: "{controller=Home}/{action=Index}/{id=Defaultvalue}");
            //id in the below route is optional
            //Catch all route isn't working for some odd reason , will have to do R&D stuff on this 
           // route.MapRoute(name: "CatchAllRoutes", template: "Home/CatchAllAction/{id?}/{*catchall}");

            //route.MapRoute(name: "OptionalParams", template: "{controller=Home}/{action=Index}/{id?}");

            //route.MapRoute(name: "OptionalParams", template: "{controller}/{action}/{id?}");


            //Traditional Way of Defining Route
            /* route.MapRoute(
                 name: "TraditionalWay", 
                 template: "{controller}/{action}",
                 defaults: new {controller = "Home", action = "Index"}
                 );

                 */
        }
    }
}
