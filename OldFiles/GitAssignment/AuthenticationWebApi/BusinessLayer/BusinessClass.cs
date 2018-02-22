using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using DTO;

namespace BusinessLayer
{
    public class BusinessClass
    {
        static HttpClient client;
        public static async Task<string> GetPassword(string username)
        {
            client= new HttpClient();
            client.BaseAddress = new Uri("http://localhost:58341/");
            var response = await client.GetStringAsync("api/UserDetails/" + username);

            return response;
        }

        public static async Task<string> Login(User userObj)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:58341/");
            string response = await client.GetStringAsync("api/UserDetails/" + userObj.Username+ "/" + userObj.Password);
           return response;
        }


        public static async Task<string> Register(User userObj)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:58341/");

           // var inputAsJson = Newtonsoft.Json.JsonConvert.DeserializeObject(input);
            HttpResponseMessage response = await client.PostAsJsonAsync("api/UserDetails/", userObj);
         
            if (response.StatusCode == HttpStatusCode.OK)
            {
               return "Registered Successfully";
            }
            else if (response.StatusCode == HttpStatusCode.Conflict )
            {
               return "Registration unsuccessful.Username already exists";
            }
            else
            {
                return "Please try after sometime.";
            }

        }
    }
}
