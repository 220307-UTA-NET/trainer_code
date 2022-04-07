using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;

namespace ClientAPITest
{
    public class Program
    {
        static async Task Main()
        {
            HttpClient client = new HttpClient();

            string response = await client.GetStringAsync("https://jsonplaceholder.typicode.com/todos");

            List<DTOs.ToDo> todo = JsonSerializer.Deserialize<List<DTOs.ToDo>>(response);

            //Console.WriteLine(response);
            foreach( var item in todo)
            {
                Console.WriteLine(item.title);
            }
            
        }
    }
}