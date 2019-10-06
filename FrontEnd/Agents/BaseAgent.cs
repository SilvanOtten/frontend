using FrontEnd.Errors;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace FrontEnd.Agents
{
    public abstract class BaseAgent
    {
        protected HttpClient _client;

        protected async Task<string> MakeRequestAsync(HttpRequestMessage request)
        {
            using var response = await _client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                string errorJson = await response.Content.ReadAsStringAsync();
                ErrorList result = JsonConvert.DeserializeObject<ErrorList>(errorJson);
                throw new FunctionalException(result);
            }
        }
    }
}
