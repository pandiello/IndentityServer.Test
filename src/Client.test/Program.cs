namespace Client.test
{
    using System;
    using System.Net.Http;
    using IdentityModel.Client;
    using Newtonsoft.Json.Linq;

    public class Program
    {
        public static  void Main(string[] args)
        {
           Execute();
            Console.ReadKey();
        }

        private static async void Execute()
        {
            var disco = await DiscoveryClient.GetAsync("http://localhost:5000");

            var tokenClient = new TokenClient(disco.TokenEndpoint, "oauthClient", "superSecretPassword");
            var tokenResponse = await tokenClient.RequestClientCredentialsAsync("customAPI.read");

            if (tokenResponse.IsError)
            {
                Console.WriteLine(tokenResponse.Error);
                return;
            }

            Console.WriteLine(tokenResponse.Json);

            var client = new HttpClient();
            client.SetBearerToken(tokenResponse.AccessToken);

            var response = await client.GetAsync("http://localhost:5005/api/values");
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode);
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();  
                Console.WriteLine(JArray.Parse(content));
            }
        }
    }
}
