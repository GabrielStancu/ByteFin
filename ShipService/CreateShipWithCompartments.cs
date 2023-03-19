using System.Net;
using System.Text.Json;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using ShipService.Business.Dtos.Requests;
using ShipService.Business.Services;

namespace ShipService
{
    public class CreateShipWithCompartments
    {
        private readonly IShipCreator _shipCreator;
        private readonly ILogger _logger;

        public CreateShipWithCompartments(IShipCreator shipCreator, ILoggerFactory loggerFactory)
        {
            _shipCreator = shipCreator;
            _logger = loggerFactory.CreateLogger<CreateShipWithCompartments>();
        }

        [Function("CreateShipWithCompartments")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var jsonRequest = await req.ReadAsStringAsync() ?? string.Empty;
            var createShip = JsonSerializer.Deserialize<CreateShipDto>(jsonRequest);

            if (createShip is null)
                return req.CreateResponse(HttpStatusCode.BadRequest);

            _logger.LogInformation($"Received the following request: [{jsonRequest}]");
            await _shipCreator.CreateShipWithCompartmentsAsync(createShip);
            _logger.LogInformation("Created ship with compartments.");

            return req.CreateResponse(HttpStatusCode.Created);
        }
    }
}
