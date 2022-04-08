using myFirstServer.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// WebApplication is the thing we're building, all packaged up into 
// a single object.

// Before we "build" we can set up things called Middleware
// these are all things that determine the functionality and 
// the bahavior of the web application.

var app = builder.Build();

app.UseMiddleware<RequireAuthorization>();

// All of this \/ \/ \/  was replaced by this /\ /\ /\ as a class

//app.Use(async (context, next) =>
//{
//   if (context.Request.Query["authorization"] == "true")
//   {
//        // "yeah, you're good. let the whatever is next on the request pipeline deal with this"
//        await next(context);
//   }
//   else
//   {
//        // if we don't have authorization... then what
//        context.Response.StatusCode = 401;
//       context.Response.ContentType = "text/plain";
//       await context.Response.WriteAsync("error! not authorized");
//   }
//});

app.UseRouting();
app.UseEndpoints(routeBuilder =>
{
    routeBuilder.MapControllers();
});

// after we have a WebApplication (the app) we need to construct its 
// request processing pipeline, using the middleware.

app.MapGet("/", () => "Hello World!");
app.MapGet("/map1", () => "Hi there!");
app.MapGet("/map2", () => "Hello Again!");

app.Run();
