using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace AOM.FIFA.ManagerPlayer.Sync.Gateway.Extensions
{
    public static class HttpExtensions
    {
        public async static Task<T> DeserializeResponseObj<T>(this HttpResponseMessage httpResponseMessage) where T : class
        {
            var body = await httpResponseMessage.Content.ReadAsStringAsync();

            var personObject = JsonSerializer.Deserialize<T>(body);

            return personObject;
        }
    }
}
