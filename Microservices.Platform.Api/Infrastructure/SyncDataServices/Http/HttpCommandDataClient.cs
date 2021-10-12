using Microservices.Platform.Api.Application.Abstractions;
using Microservices.Platform.Api.Application.Contracts;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Microservices.Platform.Api.Infrastructure.SyncDataServices.Http
{
    public class HttpCommandDataClient : ICommandDataClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public HttpCommandDataClient(HttpClient httpClient, IConfiguration configuration)
        {
            this._httpClient = httpClient;
            this._configuration = configuration;
        }

        public async Task SendPlatformToCommand(PlatformReadDto platform)
        {
            var content = new StringContent(JsonSerializer.Serialize(platform), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(_configuration["Services:CommandService"], content);
        
            if(response.IsSuccessStatusCode)
            {
                Console.WriteLine("Successful communication with the command service.");
            }
            else
            {
                Console.WriteLine("Failed communication with the command service.");
            }
        }
    }
}
