using Newtonsoft.Json;
using System.Collections.Generic;

namespace Carros.Models
{
    public class Carro
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("tipo")]
        public string Tipo { get; set; }

        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("desc")]
        public string Desc { get; set; }

        [JsonProperty("urlFoto")]
        public string UrlFoto { get; set; }
    }
}
