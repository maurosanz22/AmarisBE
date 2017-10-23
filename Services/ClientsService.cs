using Contracts.Services;
using Models;
using Models.Enumerations;
using Models.Helpers;
using Newtonsoft.Json.Linq;

namespace Services
{
    public class ClientsService : IClientsService
    {
        private const string urlMocky = "http://www.mocky.io/v2/5808862710000087232b75ac";

        private readonly IMockyConnectorService _mockyConnectorService;

        public ClientsService(IMockyConnectorService mockyConnectorService)
        {
            _mockyConnectorService = mockyConnectorService;
        }

        public ApplicationUser GetByUserName(string userName)
        {
            return Mapper(_mockyConnectorService.GetByKey(urlMocky, JsonModels.clients, "name", userName));
        }

        public ApplicationUser GetById(string id)
        {
            return Mapper(_mockyConnectorService.GetByKey(urlMocky, JsonModels.clients, "id", id));
        }

        private ApplicationUser Mapper(JToken client)
        {
            if (client != null) return Mappers.ClientMapper(client);

            return null;
        }
    }
}
