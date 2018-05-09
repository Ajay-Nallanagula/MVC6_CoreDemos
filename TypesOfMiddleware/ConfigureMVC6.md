# Markdown File

//https://docs.microsoft.com/en-us/aspnet/core/migration/proper-to-2x/
//Webapi in .net core https://stackify.com/asp-net-core-web-api-guide/


***Imp Links ________________________________________________________________________________________________________________________________________
https://docs.microsoft.com/en-us/aspnet/core/fundamentals/startup
http://pradeeploganathan.com/asp-net/asp-net-core-framework-lifecycle/ 
https://dotnetcore.gaprogman.com/2017/07/06/asp-net-core-middleware/
https://www.packtpub.com/mapt/book/application_development/9781787283688/4/ch04lvl1sec40/controller-life-cycle
***Imp Links ________________________________________________________________________________________________________________________________________


How do you prove ASP.Net is dependent on IIS ?
Application Integrated Vs Classic mode
https://stackoverflow.com/questions/716049/what-is-the-difference-between-classic-and-integrated-pipeline-mode-in-iis7


Understanding OWIN and Katana:
http://www.c-sharpcorner.com/article/understanding-asp-net-part-one-owin-and-katana/
Also look at Identity2.0.txt in the same folder

MVC 6 

Chapter 14 : Configuring Applications.

1) one of most striking changes to ASP.NET Core is the way
that an application is configured. A whole set of files— Global.asax , FilterConfig.cs , and RouteConfig.
cs —are gone and in their place are classes called Startup and Program and a set of JSON files.

2) Program and StartUp used to configure how the app works and packages it depends on. 
3) Middleware are used tohandle Http requests
3) MVC6 when compared to MVC5 the configuration has changed completely which makes the MVC6 possible to run outside of traditional IIS platform***.

What is Startup and Program ?
The Program and Startup classes and the JSON files are used to configure how an application works and what packages it depends on.

Why is it useful?
The configuration system allows applications to be tailored to their environments and to manage their package dependencies.

How is it used? 
The most important component is the Startup class, which is used to create services (which are objects that provide common functionality throughout an application, not SOAP/JSON based service like wcf) and middleware components (which are used to handle HTTP requests).

appsettings.json: 
This file is used to define application-specific settings, as described in the “Using Configuration Data” section later in this chapter.

bower.json 
This file is used by Bower to list the client-side packages that are installed into the project, as described in Chapter 6 .

bundleconfig.json
This file is used to bundle and minify JavaScript and CSS files

launchSettings.json
 This file, which is revealed by expanding the Properties item in the MVC application project, is used to specify how the application is started.
 
 Description about Program.cs :
  public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args).UseStartup<Startup2>().Build();
    }
NOTE : WebHost.CreateDefaultBuilder(args) has the following methods been called host = new WebHostBuilder() 
(new WebHostBuilder()).UseKestrel().UseContentRoot(Directory.GetCurrentDirectory()).UseIISIntegration()
All these methods are encapsulated into WebHost.CreateDefaultBuilder() which returns ,IWebHostBuilder
Also  configuration and logging code is encapsulated into CreateDefaultBuilder()simplifies the Startup file
Refer : https://andrewlock.net/exploring-program-and-startup-in-asp-net-core-2-preview1-2/

When you see the source code of CreateDefaultBuilder it looks something like this.

public static IWebHostBuilder CreateDefaultBuilder(string[] args)  
{
    var builder = new WebHostBuilder()
        .UseKestrel()
        .UseContentRoot(Directory.GetCurrentDirectory())
        .ConfigureAppConfiguration((hostingContext, config) => { /* setup config */  })
        .ConfigureLogging((hostingContext, logging) =>  { /* setup logging */  })
        .UseIISIntegration()
        .UseDefaultServiceProvider((context, options) =>  { /* setup the DI container to use */  })
        .ConfigureServices(services => 
        {
            services.AddTransient<IConfigureOptions<KestrelServerOptions>, KestrelServerOptionsSetup>();
        });

    return builder;
}


UseKestrel This method configures the Kestrel web server, as described in the “Using Kestrel Directly” sidebar.
UseContentRoot This method configures the root directory for the application, which is used for loading configuration files and delivering static content such as images, JavaScript, and CSS.
UseIISIntegration This method enables integration with IIS and IIS Express.
UseStartup This method specifies the class that will be used to configure ASP.NET, as described in the “Understanding the Startup Class” section.
Build This method combines the configurations settings provided by all the other methods and prepares them for use.

What is Kestrel:
Kestrel is a new cross-platform web server designed to run ASP.NET Core applications. It is used automatically when you run an ASP.NET Core application using IIS Express (which is the server provided by Visual Studio for use during development) or the full version of IIS, which has been the traditional web platform for .NET applications.

More Info about Kestrel : Kestrel Vs IIS
https://stackify.com/kestrel-web-server-asp-net-core-kestrel-vs-iis/
https://stackify.com/what-is-kestrel-web-server/

http://www.intstrings.com/ramivemula/articles/publish-an-asp-net-core-1-application-to-iis/

What is reverse proxy ?
https://stackoverflow.com/questions/224664/difference-between-proxy-server-and-reverse-proxy-server
https://www.youtube.com/watch?v=7DMkX72IVOc

A pair of simple definition would be

Forward Proxy: Acting on behalf of a requestor (or service consumer)

Reverse Proxy: Acting on behalf of service/content producer.

Is it possible to by pass IIS and run the application only on kestrel ??
Yes its possible 
Way 1 : The first is to click the arrow at the right edge of the IIS Express button on the Visual Studio toolbar and select the entry that matches the name of the project. This will open a new command prompt and run the application using Kestrel

Way 2: You can achieve the same effect by opening your own command prompt, navigating to the folder that contains the application’s configuration files (the one that contains the project.json file), and running the following command: dotnet run

Understanding the Startup Class :

1) Startup class can have a different name as well, any name but that type should be mentioned in Program.cs .UseStartUp<[name of Startup]>   WebHost.CreateDefaultBuilder(args).UseStartup<Startup2>().Build();

2) Startup class have two different methods 
a) ConfigureServices : ConfigureServices method so that the application can create its services . As I explain in the “Understanding
ASP.NET Services” section, services are objects that provide functionality to other parts of the application
b)Configure : The purpose of the Configure method is to set up the request pipeline , which is the set of components known as middleware
Application starts --> Startup Instantiated --> ConfigureServices()[Services Created]-->Configure()[Pipeline Prepared]-->Request Handling Starts

Some of these methods, such as AddSingleton and AddScoped , are used to register services in different ways.
The other methods, such as
AddRouting or AddCors , add individual services that are already applied by the AddMvc method