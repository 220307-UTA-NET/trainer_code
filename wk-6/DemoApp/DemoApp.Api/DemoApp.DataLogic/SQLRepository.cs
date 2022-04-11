using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Extensions.Logging;
using DemoApp.BusinessLogic;

namespace DemoApp.DataLogic
{
    public class SQLRepository : IRepository
    {
        // Fields
        private readonly string _connectionString;
        private readonly ILogger<SQLRepository> _logger;

        // Constructors
        public SQLRepository(string connectionString, ILogger<SQLRepository> logger)
        {
            this._connectionString = connectionString;
            this._logger = logger;
        }

        // Methods
        public async Task<IEnumerable<Device>> GetAllDevices()
        {
            List<Device> result = new();

            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            string cmdString =
                "SELECT Device_ID, Device_NAME, Device_Type_ID, Device_OS_ID FROM RED.Device;";

            using SqlCommand cmd = new(cmdString, connection);

            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var ID = reader.GetInt32(0);
                var Name = reader.GetString(1);
                var Type = reader.GetInt32(2);
                var OS = reader.GetInt32(3);
                result.Add(new(ID,Name,Type,OS));
            }
            await connection.CloseAsync();

            _logger.LogInformation("Executed: GetAllDevices");

            return result;
        }
        public async Task<IEnumerable<Device>> GetDevice(string Name)
        {

            List<Device> result = new();

            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            string cmdString =
                @"SELECT Device_ID, Device_Name, Device_Type_ID, Device_OS_ID FROM RED.Device " +
                "WHERE Device_Name = @Name;";

            using SqlCommand cmd = new(cmdString, connection);

            cmd.Parameters.AddWithValue("@Name", Name);

            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var ID = reader.GetInt32(0);
                var retName = reader.GetString(1);
                var Type = reader.GetInt32(2);
                var OS = reader.GetInt32(3);
                result.Add(new(ID, retName, Type, OS));
            }
            await connection.CloseAsync();

            _logger.LogInformation("Executed: GetAllDevices");

            return result;
        }
    }
}
