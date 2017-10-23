using Models.Enumerations;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace Models.Extensions
{
    public static class Extensions
    {
        public static JToken ConvertToJtoken(this string mockResult, JsonModels model, string key, string value)
        {
            return JObject.Parse(mockResult)[model.ToString()]?.FirstOrDefault(x => x[key].ToString().Equals(value));
        }

        public static IEnumerable<JToken> ConvertToList(this string mockResult, JsonModels model, string key, string value)
        {
            return JObject.Parse(mockResult)[model.ToString()]?.Where(x => x[key].ToString().Equals(value));
        }
    }
}
