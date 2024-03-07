using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ExamenWPFApp.Services
{
    internal class MiHttpClient
    {

        HttpClient _client;
        JsonSerializerOptions _serializerOptions;

        public MiHttpClient()
        {
            _client = new HttpClient();
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
                WriteIndented = true
            };
        }

        public async Task<List<T>> GetDataAsync<T>(string url)
        {
            List<T> Items = new List<T>();

            Uri uri = new Uri(string.Format(url));
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Items = (JsonSerializer.Deserialize<List<T>>(content, _serializerOptions));
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return Items;
        }
    }
}
