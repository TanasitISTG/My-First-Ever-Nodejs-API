using System;
using System.Net.Http;
using System.Text;

namespace ConsoleApplication1
{
    public class Authorization
    {
        private static readonly HttpClient Client = new HttpClient();
        
        public static void Login(string username, string password)
        {
            var requestBody = new StringContent($"{{\"username\": \"{username}\", \"password\": \"{password}\"}}", Encoding.UTF8, "application/json");

            var response = Client.PostAsync("http://localhost:3000/login", requestBody).Result;

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);
                Console.WriteLine("redirecting you to the main menu....");
            }
            else
            {
                Console.WriteLine($"Error {response.StatusCode}: {response.ReasonPhrase}");
            }
        }

        public static void Register(string username, string email, string password)
        {
            var requestBody = new StringContent($"{{\"username\": \"{username}\", \"email\": \"{email}\", \"password\": \"{password}\"}}", Encoding.UTF8, "application/json");

            var response = Client.PostAsync("http://localhost:3000/register", requestBody).Result;

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);
            }
            else
            {
                Console.WriteLine($"Error {response.StatusCode}: {response.ReasonPhrase}");
            }
        }
    }
}
