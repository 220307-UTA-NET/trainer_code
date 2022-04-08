namespace myFirstServer.Middleware
{
    public class RequireAuthorization
    {
        // Fields
        private readonly RequestDelegate _next;

        // Constructor
        public RequireAuthorization(RequestDelegate next)
        {
            this._next = next;
        }

        // Methods
        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Query["authorization"] == "true")
            {
                // "yeah, you're good. let the whatever is next on the request pipeline deal with this"
                await _next(context);
            }
            else
            {
                // if we don't have authorization... then what

                context.Response.StatusCode = 401;
                context.Response.ContentType = "text/plain";
                await context.Response.WriteAsync("error! not authorized");
            }
        }


        // logging is important
        // focus on the 6 levels of logging
        // 0 - Trace
        // 1 - Debug
        // 2 - Information
        // 3 - Warning
        // 4 - Error
        // 5 - Critical

    }
}
