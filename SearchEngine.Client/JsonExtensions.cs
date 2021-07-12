using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngine.Client.Extensions
{
    internal static class JsonExtensions
    {
        static JsonSerializerSettings settings;

        static JsonExtensions()
        {
            settings = new JsonSerializerSettings();
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            settings.NullValueHandling = NullValueHandling.Ignore;
            settings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
            settings.Converters.Add(new StringEnumConverter());

        }

        public static HttpContent ToJsonContent(this object payload)
        {
            return new StringContent(JsonConvert.SerializeObject(payload, settings), Encoding.UTF8, "application/json");
        }

        public static string ToJson(this object payload)
        {
            return JsonConvert.SerializeObject(payload, Formatting.Indented, settings);
        }

        public static async Task<T> BodyAs<T>(this HttpResponseMessage response)
        {
            string content = await response.Content.ReadAsStringAsync();
            try
            {
                return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception)
            {
                throw new Exception($"Error while DeserializeObject string {content}");
            }
        }
    }
}
