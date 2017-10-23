using Contracts.Services;
using Models;
using Models.Enumerations;
using Models.Helpers;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class PoliciesService : IPoliciesService
    {
        private const string urlMocky = "http://www.mocky.io/v2/580891a4100000e8242b75c5";

        private readonly IClientsService _clientsService;
        private readonly IMockyConnectorService _mockyConnectorService;

        public PoliciesService(IClientsService clientsService, IMockyConnectorService mockyConnectorService)
        {
            _clientsService = clientsService;
            _mockyConnectorService = mockyConnectorService;
        }

        public Policies GetById(string id)
        {
            var policie = Mapper(_mockyConnectorService.GetByKey(urlMocky, JsonModels.policies, "id", id));

            if (policie != null)
            {
                policie.Client = _clientsService.GetById(policie.Client.Id);
            }

            return policie;
        }

        public IEnumerable<Policies> GetByUserName(string userName)
        {
            var client = _clientsService.GetByUserName(userName);

            return _mockyConnectorService.GetAllById(urlMocky, JsonModels.policies, "clientId", client?.Id).Select(x => Mapper(x));
        }

        private Policies Mapper(JToken policie)
        {
            if (policie != null) return Mappers.PolicieMapper(policie);

            return null;
        }
    }
}
