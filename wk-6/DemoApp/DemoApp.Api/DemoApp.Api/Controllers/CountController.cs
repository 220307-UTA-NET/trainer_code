using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountController : ControllerBase
    {
        // Fields

        static private int count = 0;
        private readonly ILogger<CountController> _logger;


        // Constructor
        
        public CountController(ILogger<CountController> logger)
        {
            this._logger = logger;
        }

        // Methods

        // every time we call the Get method, i want to return the number of times the methd has been called.
        // GET: api/CountController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            count++;
            _logger.LogInformation("Count.Get executed. Count: {count}", count);
            return new string[] { count.ToString() };
        }

        // GET api/<CountController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            throw new NotImplementedException();
        }

        // POST api/<CountController>
        [HttpPost]
        public void Post([FromBody] string value)
        {

            throw new NotImplementedException();
        }

        // PUT api/<CountController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

            throw new NotImplementedException();
        }

        // DELETE api/<CountController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
