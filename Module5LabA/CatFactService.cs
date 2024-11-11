using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Module5LabA
{
    public static class CatFactService
    {
        // Base address for the Cat Fact API
        static readonly string BaseAddress = "https://catfact.ninja";
        static readonly string Url = $"{BaseAddress}/fact";

        // HttpClient instance
        static HttpClient client;

        // Static constructor to initialize the HttpClient
        static CatFactService()
        {
            client = new HttpClient
            {
                BaseAddress = new Uri(BaseAddress)
            };
        }

        // Method to get a random cat fact
        public static async Task<CatFact> GetRandomCatFactAsync()
        {
            // Check for network connectivity
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
                throw new Exception("No internet connection available.");

            // Get the HttpClient object
            var client = await GetClient();
            string result = await client.GetStringAsync(Url);

            // Deserialize the JSON string into a CatFact object
            return JsonSerializer.Deserialize<CatFact>(result, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            });
        }

        // Method to return an HttpClient object (can be extended as needed)
        private static Task<HttpClient> GetClient()
        {
            return Task.FromResult(client);
        }
    }

    // Model class to represent the Cat Fact
    public class CatFact
    {
        public string Fact { get; set; }
        public int Length { get; set; }
    }
}
