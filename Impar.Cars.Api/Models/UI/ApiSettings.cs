using Newtonsoft.Json;

namespace Impar.Cars.Api.Models.UI
{
    public class ApiSettings
    {
        [JsonProperty("SqlServerConnectionString")]
        public string SqlServerConnectionString { get; set; }
    }
}
