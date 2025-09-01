using Newtonsoft.Json; 
using Tarea1.Models;
using System.Net.Http;

namespace Tarea1.Services
{
    public class FrutaService
    {
        private readonly HttpClient _httpClient;

        public FrutaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<FrutaApi>> GetFrutasAsync()
{
    var url = "https://www.fruityvice.com/api/fruit/all";
    var response = await _httpClient.GetStringAsync(url);
    var frutas = JsonConvert.DeserializeObject<List<FrutaApi>>(response);
    return frutas;
}

public async Task<List<FrutaApi>> SearchFrutasAsync(string nombre)
{
    var url = $"https://www.fruityvice.com/api/fruit/{nombre}";
    var response = await _httpClient.GetStringAsync(url);
    var fruta = JsonConvert.DeserializeObject<FrutaApi>(response);
    return new List<FrutaApi> { fruta };
}

    }
}
