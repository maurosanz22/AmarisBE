using Contracts.Services;
using Models.Enumerations;
using Models.Extensions;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net;

namespace Services
{
    public class MockyConnectorService : IMockyConnectorService
    {
        public JToken GetByKey(string url, JsonModels model, string key, string value)
        {
            using (var webClient = new WebClient())
            {
                return webClient.DownloadString(url).ConvertToJtoken(model, key, value);
            }
        }

        public IEnumerable<JToken> GetAllById(string url, JsonModels model, string key, string id)
        {
            using (var webClient = new WebClient())
            {
                return webClient.DownloadString(url).ConvertToList(model, key, id);
            }
        }
    }
}
