
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace WebApiUsingConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Select an operation- 1:Get 2:Post ");
            int choice = Convert.ToInt32(Console.ReadLine());
            if (choice == 1)
            {
                Get().Wait();
            }           

            else if(choice == 2)
            {
                Post().Wait();
            }

            else
            {
                Console.WriteLine("select valid option");
            }         

        }
        static async Task Get()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:55541/");
            string response1 = await client.GetStringAsync("api/Employee/");
            Console.WriteLine(response1);
            Console.WriteLine();
            HttpResponseMessage response2 = await client.GetAsync("api/Employee/");
            var resp=await client.GetAsync("api/Employee/");
            Console.WriteLine(response2);


        }

        static async Task Post()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:55541/");
            string input = Console.ReadLine();
        
            var inputAsJson = JsonConvert.DeserializeObject(input);
            HttpResponseMessage response = await client.PostAsJsonAsync("api/Employee/", inputAsJson);
            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Post successful");
                Console.WriteLine();
            }

        }

    }
}