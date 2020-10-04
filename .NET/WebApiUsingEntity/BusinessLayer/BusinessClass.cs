using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class BusinessClass
    {
       static HttpClient client = new HttpClient();
        public    static async Task Get(string username)
        {            
            client.BaseAddress = new Uri("http://localhost:51884/");
            var response1 = await client.GetStringAsync("api/UserCredentials/"+username);
            
            Console.WriteLine(response1);
        }

        public static async Task Get(string username,string password)
        {
            client.BaseAddress = new Uri("http://localhost:51884/");
            string response1 = await client.GetStringAsync("api/UserCredentials/" + username+"/"+password);
            Console.WriteLine(response1);           
        }


        public    static async Task Post(string input)
        {
            
            client.BaseAddress = new Uri("http://localhost:51884/");
            

            var inputAsJson = Newtonsoft.Json.JsonConvert.DeserializeObject(input);
            HttpResponseMessage response = await client.PostAsJsonAsync("api/UserCredentials/", inputAsJson);
            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Success");
            }

        }

    }
}
