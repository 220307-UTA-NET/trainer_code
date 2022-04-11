using DemoApp.UI.DTOs;
using System.Net.Http.Json;
using System.Net.Mime;

namespace DemoApp.UI
{
    public class IO
    {
        // Fields
        private readonly Uri uri;

        public static readonly HttpClient httpClient = new HttpClient();

        // Constructors
        public IO (Uri uri)
        {
            this.uri = uri;
        }


        // Methods
        public async Task BeginAsync()
        {
            Console.WriteLine("ConsoleApp Running...");
            bool loop = true;

            do
            {
                int choice = MainMenu();
                switch(choice)
                {
                    case -1:
                        Console.WriteLine("Bad input, please try again.");
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadLine();
                        break;
                    case 0:
                        loop = false; break;
                    case 1:
                        await DisplayAllDevicesAsync();
                        break;
                }
            }while (loop == true);
        }

        private int MainMenu()
        {
            Console.Clear();
            int choice = -1;
            Console.WriteLine("Please select the option of your choice:");
            Console.WriteLine("[0] - Exit");
            Console.WriteLine("[1] - Get All Devices Information");
            Console.WriteLine("[2] - Get A Devices Information");
            string? input = Console.ReadLine();
            Console.Clear();
            //if (int.TryParse(input, out choice))
            //{
            //    return choice;
            //}
            //else
            //{
            //    choice = -1;
            //    return choice;
            //}
            if (!int.TryParse(input, out choice))
            { choice = -1; }
            return choice;
        }
        
        private async Task DisplayAllDevicesAsync()
        {   
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri.ToString() + "Devices");
            request.Headers.Accept.Add(new(MediaTypeNames.Application.Json));

            //try
            //{
            //    response = await httpClient.SendAsync(request);

            //}
            //catch (HttpRequestException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //    Console.WriteLine("Press any key to continue.");
            //    Console.ReadLine();
            //}

            using (HttpResponseMessage response = await httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();

                if (response.Content.Headers.ContentType?.MediaType != MediaTypeNames.Application.Json)
                {
                    throw new ArrayTypeMismatchException();
                }

                var devices = await response.Content.ReadFromJsonAsync<List<DeviceDTO>>();

                if (devices != null)
                {
                    Console.WriteLine("Devices: ");
                    foreach (var device in devices)
                    {
                        Console.WriteLine("Device Name: " + device.Name);
                    }
                }
                else
                {
                    Console.WriteLine("No devices found.");
                   
                }
            }
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadLine();
            Console.Clear();
        }
    }
}