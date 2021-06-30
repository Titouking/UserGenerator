using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.WebUtilities;

namespace UsersGenerator.Clients
{
    public class UserGenClient : IUserGenClient
    {
        private readonly HttpClient _client;
        private readonly ILogger<UserGenClient> _logger;

        private const string UserGenUrl = "https://randomuser.me/api";

        

        public UserGenClient(HttpClient client, ILogger<UserGenClient> logger)
        {
            _client = client;
            _logger = logger;
        }

        public async Task<UserGenResponse> GetRandomUser(string nationality, string password)
        {
            try
            {
                var options = new JsonSerializerOptions()
                {
                    NumberHandling = JsonNumberHandling.AllowReadingFromString |
                    JsonNumberHandling.WriteAsString
                };

                var url = GenerateURL(nationality, password);
                var responseStream = await _client.GetStreamAsync(url);
                var generatedUser = await JsonSerializer.DeserializeAsync<UserGenResponse>(responseStream, options);

                return generatedUser;
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Something went wrong when calling randomuser.me");
                return null;
            }
        }

        private static Uri GenerateURL(string nationality, string password)
        {
            var url = UserGenUrl;
            string passpolicy;
            switch (password)
            {
                case "complex":
                    passpolicy = "special,upper,lower,number,8-64";
                    break;

                case "medium":
                    passpolicy = "upper,lower,number,5-32";
                    break;

                case "easy":
                    passpolicy = "1-8";
                    break;

                default:
                    passpolicy = "";
                    break;
            }

            var param = new Dictionary<string, string>() { { "nat", nationality }, { "password", passpolicy}, { "noinfo", "true" } };
            
            var newUrl = new Uri(QueryHelpers.AddQueryString(url, param));

            return newUrl;
        }
    }
}
