using Carros.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Carros.Services
{
    public class CarrosAPI
    {
        readonly string _api_base_url = "http://carros-env.twpdxsvkdy.us-east-2.elasticbeanstalk.com/carros_rest_aws/rest";

        public async Task<List<Carro>> GetAllCarrosAsync()
        {
            //grab json from server
            var json = await GetJsonData($"{_api_base_url}/carros/?api_key=6d9e70e3c714d4b4448273ae107dccd569&page=1");

            //Deserialize json
            var items = JsonConvert.DeserializeObject<List<Carro>>(json);

            //return the items
            return items;
        }

        async Task<string> GetJsonData(string url)
        {
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync(url);
                return json;
            }
        }
    }
}
