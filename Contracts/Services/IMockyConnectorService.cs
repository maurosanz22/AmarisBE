using Models.Enumerations;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Contracts.Services
{
    public interface IMockyConnectorService
    {
        JToken GetByKey(string url, JsonModels model, string key, string value);

        IEnumerable<JToken> GetAllById(string url, JsonModels model, string key, string id);
    }
}
