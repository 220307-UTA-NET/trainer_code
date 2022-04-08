using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace myFirstServer.SampleController
{
    // ASP.NET uses 'refletion' to automjically 
    // find classes that follw a naming convention 
    // ("__________Controller")



    [Route("api/[controller]")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        // a controllers job is to handle a subset of requests to the server
        // based on the URL path and the HTTP method

        // each category of request (GET, PUT, etc) with the same things to do
        // will be one method in this class

        private static readonly List<int> s_sample = new() { 12 };



        [HttpGet("/sample")]
        public ContentResult GetSample()
        {
            string json = JsonSerializer.Serialize(s_sample);

            var result = new ContentResult()
            {
                StatusCode = 200,
                ContentType = "application/json",
                Content = json
            };

            return result;
        }

        [HttpPost("/sample")]
        public ContentResult AddSample([FromBody] int sample)
        {
            s_sample.Add(sample);
            string json = JsonSerializer.Serialize(s_sample);

            return new ContentResult()
            {
                StatusCode = 201,
                ContentType = "application/json",
                Content = json
            };
        }





    }
}
