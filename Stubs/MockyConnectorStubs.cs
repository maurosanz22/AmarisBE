using Models.Enumerations;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using Models.Extensions;

namespace Stubs
{
    public static class MockyConnectorStubs
    {
        public static JToken GetClient(string key, string value)
        {
            return Resources.ClientMockResult.ConvertToJtoken(JsonModels.clients, key, value);
        }

        public static IEnumerable<JToken> GetPolicies(string key, string value)
        {
            return Resources.PoliciesMockResult.ConvertToList(JsonModels.policies, key, value);
        }
    }
}
