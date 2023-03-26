using System.Net;
using System.Text.Json;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using ShipService.Business.GetShipsInfo;
using ShipService.Contracts.CreateShipCompartments;

namespace ShipService
{
    public class GetShipsInfo
    {
        private readonly IShipInfoService _shipInfoService;
        private readonly ILogger _logger;

        public GetShipsInfo(IShipInfoService shipInfoService, ILoggerFactory loggerFactory)
        {
            _shipInfoService = shipInfoService;
            _logger = loggerFactory.CreateLogger<GetShipsInfo>();
        }

        [Function("GetShipsInfo")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var shipsInfoResponse = await _shipInfoService.GetShipsInfoAsync();
            var jsonShipsInfoResponse = JsonSerializer.Serialize(shipsInfoResponse);

            _logger.LogInformation($"Found info about the following ships: [{jsonShipsInfoResponse}]");

            var response = req.CreateResponse(HttpStatusCode.OK);
            await response.WriteStringAsync(jsonShipsInfoResponse);

            return response;
        }
    }
}
