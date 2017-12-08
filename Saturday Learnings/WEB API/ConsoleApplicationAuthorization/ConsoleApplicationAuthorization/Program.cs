using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationAuthorization
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpClientHandler handler = new HttpClientHandler();
            HttpClient client = new HttpClient(handler);
            Console.WriteLine("Enter UserName");
            string username = Console.ReadLine();
            Console.WriteLine("Enter Password");
            string password = Console.ReadLine();
            string headervalue = username + ':' + password;
            client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", headervalue);
            var result = client.GetAsync(new Uri("http://localhost:54964/api/test/")).Result;
            if (result.IsSuccessStatusCode)
            {
                Console.WriteLine("Done" + result.StatusCode);
                Console.WriteLine(result.Content.ReadAsStringAsync().Result);


            }
            else
                Console.WriteLine("Error" + result.StatusCode);
            Console.ReadLine();
        }
    }
}
