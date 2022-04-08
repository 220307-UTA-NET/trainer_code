var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// WebApplication is the thing we're building, all packaged up into 
// a single object.

// Before we "build" we can set up things called Middleware
// these are all things that determine the functionality and 
// the bahavior of the web application.

var app = builder.Build();

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
