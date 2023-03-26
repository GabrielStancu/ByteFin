using System.Net;
using System.Text.Json;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using ShipService.Contracts.CreateShipCompartments;

namespace ShipService
{
    public class GetShipsInfo
    {
        private readonly ILogger _logger;

        public GetShipsInfo(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<GetShipsInfo>();
        }

        [Function("GetShipsInfo")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var jsonRequest = await req.ReadAsStringAsync() ?? string.Empty;
            var createShip = JsonSerializer.Deserialize<CreateShipCompartmentsRequest>(jsonRequest);

            if (createShip is null)
                return req.CreateResponse(HttpStatusCode.BadRequest);

            _logger.LogInformation($"Received the following request: [{jsonRequest}]");
            await _shipCreator.CreateShipWithCompartmentsAsync(createShip);
            _logger.LogInformation("Created ship with compartments.");

            return req.CreateResponse(HttpStatusCode.Created);
        }
    }
}
