using Newtonsoft.Json;

namespace LojaQualquer.WebApi.Domain.Models.Response
{
    public class ResponseError
    {
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}