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
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.DependencyInjection;
using RoutingMVC6.CustomRoute;
using Action = Microsoft.Azure.KeyVault.Models.Action;

namespace RoutingMVC6
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<RouteOptions>(options =>
            {
                options.ConstraintMap.Add("month", typeof(MonthRouteContraint));
                options.ConstraintMap.Add("weekday", typeof(WeekDayRouteConstraint));
            });

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
            //Custom Route Constraint
           /* route.MapRoute(
                name: "CustRoute",
                template: "{controller}/{action}/{month?}/{weekday?}/{day?}",
                defaults: new{controller="RouteTest",action="Index"},
                constraints: new
                {
                    month = new MonthRouteContraint(),
                    weekday =new WeekDayRouteConstraint() ,
                    day = new CompositeRouteConstraint(new List<IRouteConstraint>{new IntRouteConstraint(),new RangeRouteConstraint(1,31)})
                } 
            );*/

            route.MapRoute(name: "SrtCustRoute",
                template:
                "{controller=RouteTest}/{action=Index}/{month:month?}/{weekday:weekday?}/{day:int:range(1,31)?}");


            //id is Custom Url Segment, with default value as "Defaultvalue" , id in the below route is optional
            //route.MapRoute(name: "FirstRoute", template: "{controller=Home}/{action=Index}/{id}"); //=Defaultvalue





            /* Catch all route isn't working for some odd reason , will have to do R&D stuff on this 
             route.MapRoute(name: "CatchAllRoutes", template: "Home/CatchAllAction/{id?}/{*catchall}");

             route.MapRoute(name: "OptionalParams", template: "{controller=Home}/{action=Index}/{id?}");

             route.MapRoute(name: "OptionalParams", template: "{controller}/{action}/{id?}");


             Traditional Way of Defining Route
              route.MapRoute(
                  name: "TraditionalWay", 
                  template: "{controller}/{action}",
                  defaults: new {controller = "Home", action = "Index"}
                  );

                  */
        }
    }
}
