using Newtonsoft.Json.Linq;
using System;

namespace Models.Helpers
{
    public static class Mappers
    {
        public static ApplicationUser ClientMapper(JToken client)
        {
            return new ApplicationUser
            {
                Role = client["role"].ToString(),
                UserName = client["name"].ToString(),
                Email = client["email"].ToString(),
                Id = client["id"].ToString() };
        }

        public static Policies PolicieMapper(JToken policie)
        {
            return new Policies
            {
                Id = policie["id"].ToString(),
                AmountInsured = Convert.ToDecimal(policie["amountInsured"]),
                Email = policie["email"].ToString(),
                InceptionDate = Convert.ToDateTime(policie["inceptionDate"]),
                InstallmentPayment = Convert.ToBoolean(policie["installmentPayment"]),
                Client = new ApplicationUser { Id = policie["clientId"].ToString() }
            };
        }
    }
}
