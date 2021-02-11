using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace System.Net.Http
{
    public static class TestHttpClientExtensions
    {
        public static Task<HttpResponseMessage> PostAsJsonAsync<TRequest>(this HttpClient client, string url, TRequest request)
        {
            var content = new StringContent(
                              JsonSerializer.Serialize(request),
                              Encoding.UTF8,
                              "application/json");

            return client.PostAsync(url, content);
        }

        public static async Task<TType> ReadAsTypeAsync<TType>(this HttpContent httpContent)
        {
            var stringContent = await httpContent.ReadAsStringAsync();
            var typeData = JsonSerializer.Deserialize<TType>(stringContent);

            return typeData ?? default;
        }
    }
}
