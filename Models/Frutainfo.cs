using Newtonsoft.Json;

namespace Tarea1.Models
{
    public class FrutaApi
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string? Nombre { get; set; }

        [JsonProperty("genus")]
        public string? Genero { get; set; }

        [JsonProperty("family")]
        public string? Familia { get; set; }

        [JsonProperty("order")]
        public string? Orden { get; set; }

        [JsonProperty("nutritions")]
        public Nutricion? Nutriciones { get; set; }
    }

    public class Nutricion
    {
        [JsonProperty("carbohydrates")]
        public double Carbohidratos { get; set; }

        [JsonProperty("protein")]
        public double Proteina { get; set; }

        [JsonProperty("fat")]
        public double Grasa { get; set; }

        [JsonProperty("calories")]
        public double Calorias { get; set; }

        [JsonProperty("sugar")]
        public double Azucar { get; set; }
    }
}
