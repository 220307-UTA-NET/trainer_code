using DemoApp.BusinessLogic;
using DemoApp.DataLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace DemoApp.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        // Fields
        private readonly IRepository _repository;
        private readonly ILogger<DeviceController> _logger;

        // Constructors
        public DeviceController(IRepository repository, ILogger<DeviceController> logger)
        {
            this._repository = repository;
            this._logger = logger;
        }

        // Methods
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Device>>> GetDeviceByNameAsync(string id)
        {
            IEnumerable<Device> devices;
            try
            {
                devices = await _repository.GetDevice(id);
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "SQL error while getting devices named {id}.", id);
                return StatusCode(500);
            }
            return devices.ToList();
        }
    }
}
