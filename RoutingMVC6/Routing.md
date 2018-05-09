https://docs.microsoft.com/en-us/aspnet/core/fundamentals/startup

MSDN Url : https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/routing

Routing Under the hood: http://www.inversionofcontrol.co.uk/asp-net-core-1-0-routing-under-the-hood/


URL ROUTING :pg425

What is routing ?? (definition only)
https://www.codeproject.com/Tips/573454/Routing-in-MVC
 Routing is a mechanism in MVC that decides which action method of a controller class to execute. Without routing there’s no way an action method can be mapped to a request. Routing is a part of the MVC architecture so ASP.NET MVC supports routing by default.  "routing decouples the request handler from the URL  request"
 ASP.NET introduced Routing to eliminate needs of mapping each URL with a physical file. Routing enable us to define URL pattern that maps to the request handler. This request handler can be a file or class. In ASP.NET Webform application, request handler is .aspx file and in MVC, it is Controller class and Action method. For example, http://domain/students can be mapped to http://domain/studentsinfo.aspx in ASP.NET Webforms and the same URL can be mapped to Student Controller and Index action method in MVC.
 
 The routing system has two functions:
 Incoming Urls : select the controller and action to handle the request
 Outgoing Urls: These are the URLs that appear in the HTML rendered from views so that a specific action will be invoked when the user clicks the link (at which point, it becomes an incoming URL again).
 
 
 Routing between MVC5 Vs MVC6
 a) RouteConfig.cs is now obsolete the routes are configured in StartUp.cs file now.
 b) Routing related constructs are now available in Microsoft.AspnetCore.Routing , till MVC5 there routing was resindin inside System.Web.Routing
 c) Routes no longer match URLs if there is no corresponding controller and action method in the application
 d) Convention-based default values, optional segments, and route constraints can now be expressed as part of the URL pattern, using the same syntax as with attribute-based routing
 e) Requests for static files (such as images, CSS, and JavaScript) are now handled by dedicated middleware
 //Inside StartUp.cs ->Configure -> app.UseStaticFiles();
 
 
 Difference between AddMvcCore() Vs AddMvc() 
 https://github.com/aspnet/Mvc/issues/2872
 
 How to deploy your asp.net core application on IIS ?
 http://www.c-sharpcorner.com/blogs/how-to-publish-and-deploy-net-core-website-on-iis 
 https://docs.microsoft.com/en-us/aspnet/core/publishing/iis?tabs=aspnetcore2x
 
 //**** START CONVENTION-BASED ROUTING.
 Default Routes :
 Till MVC5 default routes were given as follows :
  routes.MapRoute(
        name: "Default",
        url: "{controller}/{action}/{id}",
        defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
    );

From MVC6 onwards : There are two ways 
First way is similar to that of MVC5 can be done , 
Sencond way is inline default routes :
Example : route.MapRoute(name: "FirstRoute", template: "{controller=Home}/{action=Index}");

Route Ordering :
The routing system tries to match an incoming URL against the URL pattern of the route that was defined first and proceeds to the next route only if there is no match
 
Defining Custom Segment Variables :
1) Controller and Action are only the built-in segment variables, and custom segment variables can also be defined for ex
2) app.UseMvc(routes => {
routes.MapRoute(name: "MyRoute",
template: "{controller=Home}/{action=Index}/{id=DefaultId}");
});
//Id here is the custom variable segment

3) How do we retrieve the custom variable segment ??
The Controller class, which is the base for controllers, defines a RouteData property that returns a
Microsoft.AspNetCore.Routing.RouteData
can access any of the segment variables
in an action method by using the RouteData.Values property, which returns a dictionary containing
the segment variables.
r.Data["id"] = RouteData.Values["id"];
return View("Result", r);

Using Custom Variables as Action Method Parameters
4. MVC compares the list of segment variables with the list of action method parameters and, if the names match, passes the values from the URL to the method
5. MVC uses the m odel binding feature to convert the values contained in the URL to .NET types, and
model binding can handle much more complex situations than shown in this example.

Defining Optional URL Segments: Pg 446
6. An optional URL segment is one that the user does not need to specify and for which no default value is
specified. An optional segment is denoted by a question mark (the ? character) after the segment name
Ex:
Way 1: app.UseMvc(routes => {
routes.MapRoute(name: "MyRoute",
template: "{controller=Home}/{action=Index}/{id?}");
});


UseMvc Vs UseUseMvcWithDefaultRoute ?

UseUseMvcWithDefaultRoute can be used to replace the below mentioned route only, 
app.UseMvc(routes =>
{
   routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
});
NOTE : For other routes you need to use UseMvc only, which would take Action<IRouteBuilder> configureRoutes param , the difference between two method signatures is :

public static IApplicationBuilder UseMvc(this IApplicationBuilder app);
public static IApplicationBuilder UseMvc(this IApplicationBuilder app, Action<IRouteBuilder> configureRoutes);
public static IApplicationBuilder UseMvcWithDefaultRoute(this IApplicationBuilder app);

If you have different set of defaults you will have to fall back to using app.UseMvc(),Or You can use Attribute Routing.

Defining Variable-Length Routes :
app.UseMvc(routes => {
routes.MapRoute(name: "MyRoute",
template: "{controller=Home}/{action=Index}/{id?}/{*catchall}");
});

This will catch any route.

public ViewResult List(string id) {
Result r = new Result {
Controller = nameof(HomeController),
Action = nameof(List),
};
r.Data["id"] = id ?? "<no value>";
r.Data["catchall"] = RouteData.Values["catchall"];
return View("Result", r);
}


Constraining Routes : 

WAY 1: Inline Constraints (Not Supported till MVC5)
app.UseMvc(routes => {
routes.MapRoute(name: "MyRoute",
template: "{controller=Home}/{action=Index}/{id:int?}");
});

This is an example of an inline constraint,
The int constraint only allows the URL pattern to match segments whose value can be parsed to an
integer value. The id segment is optional, so the route will match segments that omit the id segment, but if
the segment is present, then it must be an integer value,

Other inline Constraints can be :
alpha "{controller=Home}/{action=Index}/{id:alpha?}")
bool "{controller=Home}/{action=Index}/{id:bool?}")
datetime "{controller=Home}/{action=Index}/{id:datetime?}")
decimal "{controller=Home}/{action=Index}/{id:decimal?}")
double  "{controller=Home}/{action=Index}/{id:double?}")
float "{controller=Home}/{action=Index}/{id:float?}")
guid "{controller=Home}/{action=Index}/{id:guid?}")
int "{controller=Home}/{action=Index}/{id:int?}")
length(len)  "{controller=Home}/{action=Index}/{id:length(10)?}")
length(min, max) "{controller=Home}/{action=Index}/{id:length(10,20)?}")
long "{controller=Home}/{action=Index}/{id:long?}")
maxlength(len) "{controller=Home}/{action=Index}/{id:maxlength(30)?}")
max(val) "{controller=Home}/{action=Index}/{id:maxlength(1000)?}") //Max value can be 1000
minlength(len) "{controller=Home}/{action=Index}/{id:minlength(30)?}")
min(val) "{controller=Home}/{action=Index}/{id:min(30)?}") //Min value can be 30
range(min, max) "{controller=Home}/{action=Index}/{id:range(30,40)?}")
regex(expr) "{controller=Home}/{action=Index}/{id:regex(<any valid regexpr>)?}")


/Home/CustomVariable/Hello  // Not a matching URL
/Home/CustomVariable/1  //Matching URL

Way 2: Constraint Argument

app.UseMvc(routes => {
routes.MapRoute(name: "MyRoute",
template: "{controller}/{action}/{id?}",
defaults: new { controller = "Home", action = "Index" },
constraints: new { id = new IntRouteConstraint() });
});

1) The constraints argument to the MapRoute method is defined using an anonymous type whose, property names correspond to the segment variable being constrained. 
2) The Microsoft.AspNetCore.Routing.Constraints namespace contains a set of classes that can be used to define individual constraints.

Inline Constraint -Description Class - Name
alpha Matches alphabet characters,irrespective of case (A–Z, a–z) AlphaRouteConstraint()
bool Matches a value that can be parsed into a bool BoolRouteConstraint()
datetime Matches a value that can be parsed into a DateTime DateTimeRouteConstraint()
decimal Matches a value that can be parsed into a decimal DecimalRouteConstraint()
double Matches a value that can be parsed into a double DoubleRouteConstraint()
float Matches a value that can be parsed into a float FloatRouteConstraint()
guid Matches a value to a globally unique identifier GuidRouteConstraint()
int Matches a value that can be parsed into an int IntRouteConstraint()
length(len) Matches a value with the specified number of characters or that is between min and max characters in length (inclusive) LengthRouteConstraint(len) 
length(min, max)  Matches a value with the specified number of characters or that is between min and max characters in length (inclusive) LengthRouteConstraint (min, max)
long Matches a value that can be parsed into a long LongRouteConstraint()
maxlength(len) Matches a string with no more than len characters MaxLengthRouteConstraint(len)
max(val) Matches an int value if the value is less than val MaxRouteConstraint(val)
minlength(len) Matches a string with at least len characters MinLengthRouteConstraint(len)
min(val) Matches an int value if the value is more than val MinRouteConstraint(val)
range(min, max) Matches an int value if the value is between min and max (inclusive) RangeRouteConstraint (min, max) 
regex(expr) Matches a regular expression RegexRouteConstraint(expr).

Constraining a route using a regular expression
app.UseMvc(routes => {
routes.MapRoute(name: "MyRoute",
template: "{controller:regex(^H.*)=Home}/{action=Index}/{id?}");
});

Default values are applied before constraints are checked. So, for example, if I request the URL /, the default value for controller, which is Home, is applied. The constraints are then checked, and since the
controller value begins with H, the default URL will match the route 

app.UseMvc(routes => {
routes.MapRoute(name: "MyRoute",
template: "{controller:regex(^H.*)=Home}/{action:regex(^Index$|^About$)=Index}/{id?}");
});
This constraint will allow the route to match only URLs where the value of the action segment is Index or About. Constraints are applied together, so the restrictions imposed on the value of the action variable are combined with those imposed on the controller variable. This means that the route in Listing 15-27 will match URLs only when the controller variable begins with the letter H and the action variable is Index or About.

Using Type and Value Constraints: .net core convertible datatypes
app.UseMvc(routes => {
routes.MapRoute(name: "MyRoute",
template: "{controller=Home}/{action=Index}/{id:range(10,20)?}");
});
The constraint in this example has been applied to the optional id segment. The constraint will be ignored if the request URL doesn’t have at least three segments. If the id segment is present, the route will
match the URL only if the segment value can be converted to an int and the value is between 10 and 20. The range constraint is inclusive, meaning that values of 10 and 20 are considered to be within the range.

Combining Constraints :
Way 1: 
app.UseMvc(routes => {
routes.MapRoute(name: "MyRoute",
template: "{controller=Home}/{action=Index}/{id:alpha:minlength(6)?}");
});


Way 2: Microsoft.AspNetCore.Routing.CompositeRouteConstraint
If you are not using inline constraints, then you must use the Microsoft.AspNetCore.Routing.CompositeRouteConstraint class, which allows multiple constraints to be associated with a single property in
an anonymously typed object. Listing 15-30 shows the combination of constraints that I used
app.UseMvc(routes => {
routes.MapRoute(name: "MyRoute",
template: "{controller}/{action}/{id?}",
defaults: new { controller = "Home", action = "Index" },
constraints: new { id = new CompositeRouteConstraint(
new IRouteConstraint[] {
new AlphaRouteConstraint(),
new MinLengthRouteConstraint(6)
})
});

Defining a Custom Constraint :
If the standard constraints are not sufficient for your needs, you can define your own custom constraints by
implementing the IRouteConstraint interface, which is defined in the Microsoft.AspNetCore.Routing
namespace.

Implementation 
public class WeekDayConstraint : IRouteConstraint {
private static string[] Days = new[] { "mon", "tue", "wed", "thu",
"fri", "sat", "sun" };
public bool Match(HttpContext httpContext, IRouter route,
string routeKey, RouteValueDictionary values,
RouteDirection routeDirection) {
return Days.Contains(values[routeKey]?.ToString().ToLowerInvariant());
}
}

Usage Way 1:
app.UseMvc(routes => {
routes.MapRoute(name: "MyRoute",
template: "{controller}/{action}/{id?}",
defaults: new { controller = "Home", action = "Index" },
constraints: new { id = new WeekDayConstraint() });
});

Usage Way 2:  Inline

Step 1: 
public class Startup {
public void ConfigureServices(IServiceCollection services) {
// **** IMPORTANT LINE
services.Configure<RouteOptions>(options =>
options.ConstraintMap.Add("weekday", typeof(WeekDayConstraint)));
// **** IMPORTANT LINE

services.AddMvc();
}

Step 2:
app.UseMvc(routes => {
routes.MapRoute(name: "MyRoute",
template: "{controller=Home}/{action=Index}/{id:weekday?}");
});

 //**** END CONVENTION-BASED ROUTING.


Using Attribute Routing : Recommended By Microsoft
1) Attribute routing is enabled when you call the UseMvc method in the Startup.cs
2) Create and configure routes using attributes, which can be mixed freely with the convention-based routes

[Route("myroute")]
public ViewResult Index() => View("Result",
new Result {
Controller = nameof(CustomerController),
Action = nameof(Index)
});

The first is that when you use the Route attribute, the value you
provide to configure the attribute is used to define a complete route so that myroute becomes the complete
URL to reach the Index action method. The second point to note is that using the Route attribute prevents
the default routing configuration from being used so that the Index action method can no longer be reached
by using the /Customer/Index URL.

[Route("[controller]/MyAction")]
public ViewResult Index() => View("Result",
new Result {
Controller = nameof(CustomerController),
Action = nameof(Index)
});

Using the [controller] token in the argument for the Route attribute is rather like using a nameof
expression and allows for the route to the controller to be specified without hard-coding the class name.
https://www.strathweb.com/2015/01/asp-net-mvc-6-attribute-routing-controller-action-tokens/

[Route("app/[controller]/actions/[action]/{id?}")]
public class CustomerController : Controller {
public ViewResult Index() => View("Result",
new Result {
Controller = nameof(CustomerController),
Action = nameof(Index)
});

This route defines mixes static segments and variable segments and uses the [controller] and
[action] tokens to refer to the names of the controller class and the action methods

Applying Route Constraints:
[Route("app/[controller]/actions/[action]/{id:weekday?}")]
public class CustomerController : Controller {
public ViewResult Index() => View("Result",
new Result {
Controller = nameof(CustomerController),
Action = nameof(Index)
});

Chapter 16 : Advanced Routing pg469
1. Different techniques for generating outgoing URLs

Generating Outgoing URLs in Views
What happens if I give a url this way 
<a href="/Home/CustomVariable">This is an outgoing URL</a>
When your Url schema changes , we will have to go thru entire application to change the urls in anchor elements, tedious task.
A better alternative is to use the routing system to
generate outgoing URLs, which ensures that the URL scheme is used to produce the URLs dynamically and in a way that is guaranteed to reflect the URL schema of the application.

Ex 1: 
<a asp-action="CustomVariable">This is an outgoing URL</a>
asp-action is a tagHelper attribute introduced in MVC6
we need to add the tag helper bu writing this line 
@addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
We also have the provision to remove the taghelpers using 
@removeTagHelper AnchorTagHelper,Microsoft.AspNetCore.Mvc.TagHelpers

It is important to checkyour outgoing URL generation. If you try to generate a URL for which no matching route can be found,you will create a link that contains an empty href attribute, like this: <a href="">This is an outgoing URL</a>

To be clear, the routing system doesn’t try to find the route that provides the best matching route. It finds only the first match, at which point it uses the route to generate the URL;

Targeting Other Controllers: asp-controller Pg479

Generating Fully Qualified URL's
<a asp-controller="Home" asp-action="Index" asp-route-id="Hello" asp-protocol="https" asp-host="myserver.mydomain.com" asp-fragment="myFragment"> This is an outgoing URL </a>
This will generate url like https://myserver.mydomain.com/Home/Index/Hello#myFragment
NOTE : Be careful when you use fully qualified URLs because they create dependencies on the application
infrastructure and, when the infrastructure changes, you will have to remember to make corresponding
changes to the MVC views.

Generating a URL from a Specific Route

Step 1: Consider you route is defined as below:
routes.MapRoute(name: "namedRoute",template: "outbound/{controller=Home}/{action=Index}"); });

Step 2: Configure your route in view as below
<a asp-controller="Home" asp-action="CustomVariable">This is an outgoing URL</a>
<a asp-route="namedRoute">This is an outgoing URL</a>

NOTE : when you use asp-route we cannot use "asp-controller","asp-action" attributess.

Rendered Output
<a href="/Home/CustomVariable">This is an outgoing URL</a>
<a href="/outbound">This is an outgoing URL</a>

Note : The problem with relying on route names to generate outgoing URLs is that doing so breaks through the
separation of concerns that is so central to the MVC design pattern. When generating a link or a URL in
a view or action method, I want to focus on the action and controller that the user will be directed to,
not the format of the URL that will be used. By bringing knowledge of the different routes into the views
or controllers, I am creating dependencies that could be avoided. In my own projects, I tend to avoid
naming my routes (by specifying null for the name argument) and prefer to use code comments to
remind myself of what each route is intended to do.

Generating URLs (and Not Links): @Url.Action
<p>URL: @Url.Action("CustomVariable", "Home", new { id = 100 })</p>
Rendered Output : <p>URL: /Home/CustomVariable/100</p>

Generating URLs in Action Methods: 
public ViewResult CustomVariable(string id) {
Result r = new Result {
Controller = nameof(HomeController),
Action = nameof(CustomVariable),
};
r.Data["Id"] = id ?? "<no value>";
r.Data["Url"] = Url.Action("CustomVariable", "Home", new { id = 100 }); // Here the URL will be Generated
return View("Result", r);
}

Customizing the Routing System:
Example to Customise:
public class Startup {
public void ConfigureServices(IServiceCollection services) {
services.Configure<RouteOptions>(options => {
options.ConstraintMap.Add("weekday", typeof(WeekDayConstraint));
options.LowercaseUrls = true;
options.AppendTrailingSlash = true;
});
services.AddMvc();
}

Creating a Custom Route Class:

In Case you want to implement Specific routing for your application , We can always use by deriving from Microsoft.AspnetCore.Routing.IRouter
namespace Microsoft.AspNetCore.Routing {
public interface IRouter {
Task RouteAsync(RouteContext context);
VirtualPathData GetVirtualPath(VirtualPathContext context);
}
}

RouteAsync method is used to handle Incoming Requests
GetVirtualPath is used to handle Outgoing Requests

Scenario of using Custom Route class derived from IRouter:
I am going to create a custom routing class that will handle legacy URL requests.
Imagine that I have migrated an existing application to MVC, but some users have bookmarked the pre-MVC
URLs or hard-coded them into scripts. I still want to support those old URLs. I could handle this using the
regular routing system, but this problem provides a nice example for this section.

Routing Incoming URLS
Sample implementation of RouteAsync 

public Task RouteAsync(RouteContext context) {
string requestedUrl = context.HttpContext.Request.Path
.Value.TrimEnd('/');
if (urls.Contains(requestedUrl, StringComparer.OrdinalIgnoreCase)) {
context.Handler = async ctx => {
HttpResponse response = ctx.Response;
byte[] bytes = Encoding.ASCII.GetBytes($"URL: {requestedUrl}");
await response.Body.WriteAsync(bytes, 0, bytes.Length);
};
}
return Task.CompletedTask;
}

RouteAsync Method is responsible for assessing wether a request can be handled or not
RouteContext Parameter consists of everything that aincoming request needs
Route Context have three important Parameters
a) RouteData, b) HttpContext,c) Handler
RouteData: this object
is used to define the controller, the action method, and the arguments that will be used to handle the request.
HttpContext : which provides access to details of the HTTP request and the means to produce the HTTP response.
Handler : This property is used to provide the routing system with a RequestDelegate that
will handle the request, If this is not mentioned the routing config i.e MapRoute is searcched in current application if found will execute that else will throw an Http404

namespace Microsoft.AspNetCore.Http {
public delegate Task RequestDelegate(HttpContext context);
}

Apply Custom Route :




//ATTRIBUTE ROUTING IN MVC5 BASICS:

Routing Concepts: 

HttpMethodConstraint, to restrict a given method to get/post/put/delete 
routes.MapRoute("MyRoute", "{controller}/{action}/{id}/{*catchall}",
new { controller = "Home", action = "Index", id = UrlParameter.Optional },
new {
controller = "^H.*", action = "Index|About",
httpMethod = new HttpMethodConstraint("GET") // This is valid as well HttpMethodConstraint("GET","POST")
},
new[] { "URLsAndRoutes.Controllers" });
}

Attribute Routing:
1) Calling the MapMvcAttributeRoutes method causes the routing system to inspect the controller classes in the application and look for attributes that configure routes.
public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes(); //For Attribute routing to be enabled this has to be called
	    }

2) When an action method is decorated with the Route attribute, it can no longer be accessed through the convention-based routes defined in the RouteConfig.cs file
3) You can apply the Route attribute to the same action method multiple times and each instance will create a new route.

        [Route("listAll")] //URL : http://localhost:49210/ListAll
        [Route("customer/listAllXYZ")] //URL : http://localhost:49210/customer/listAllXYZ
        public ActionResult List()
        {
            ViewBag.Controller = "Customer";             ViewBag.Action = "List";            return View();
        }
4) Applying Route Constraints
[Route("Users/Add/{user}/{id:int}")]
public string Create(string user, int id) {
return string.Format("Create Method - User: {0}, ID: {1}", user, id);
}

5) Combining Constraints
[Route("Users/Add/{user}/{password:alpha:length(6)}")]
public string ChangePass(string user, string password) {
return string.Format("ChangePass Method - User: {0}, Pass: {1}",user, password);
}

6) Using a Route Prefix
You can use the RoutePrefix attribute to define a common prefix that will be applied to all of the routes defined in a controller, which can be useful when you have multiple action methods that should be targeted using the same URL
root
[RoutePrefix("Users")]
public class CustomerController : Controller {

[Route("Add/{user}/{id:int}")] //URL in the browser should be http://localhost:49210/Users/Add/adam/100
public string Create(string user, int id) {
return string.Format("Create Method - User: {0}, ID: {1}", user, id);
}

}

What if you dont want a particular action method inside the controller to have the RoutePrefix , example below . Yo can gikve '~/' operator to the defined route
[Route("~/Test")] //URL in the browser should be http://localhost:49210/Test
public ActionResult Index() {
ViewBag.Controller = "Customer";
ViewBag.Action = "Index";
return View("ActionName");
}

Advanced Routing:
