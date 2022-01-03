using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManager.Services
{
    public static class APIConnection
    {
        public static string baseUrl = "https://financemanagerapi20220102223217.azurewebsites.net";

        public async static Task<List<T>> GetCollection<T>(string endUrl)
        {
            using (var c = new HttpClient())
            {
                HttpClient client = new HttpClient();

                var response = await client.GetAsync(new Uri(baseUrl + endUrl));

                List<T> Items = new List<T>();
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    Items = JsonConvert.DeserializeObject<List<T>>(content);
                }

                return Items;
            }
        }

        public async static Task<List<T>> GetCollectionElement<T>(string endUrl, int elementId)
        {
            using (var c = new HttpClient())
            {
                HttpClient client = new HttpClient();

                var response = await client.GetAsync(new Uri($"{baseUrl}{endUrl}/{elementId}"));

                List<T> Items = new List<T>();
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    var item = JsonConvert.DeserializeObject<T>(content);
                    Items.Add(item);
                }

                return Items;
            }
        }

        public async static Task<bool> AddCollectionElement<T>(string endUrl, T element)
        {
            using (var c = new HttpClient())
            {
                HttpClient client = new HttpClient();

                var serializedJsonRequest = JsonConvert.SerializeObject(element);
                HttpContent content = new StringContent(serializedJsonRequest, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(new Uri($"{baseUrl}{endUrl}"), content);

                if (response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    return true;
                }

                return false;
            }
        }

        public async static Task<bool> UpdateCollectionElement<T>(string endUrl, T element, int elementID)
        {
            using (var c = new HttpClient())
            {
                HttpClient client = new HttpClient();

                var serializedJsonRequest = JsonConvert.SerializeObject(element);
                HttpContent content = new StringContent(serializedJsonRequest, Encoding.UTF8, "application/json");

                var response = await client.PutAsync(new Uri($"{baseUrl}{endUrl}/{elementID}"), content);

                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return true;
                }

                return false;
            }
        }

        public async static Task<bool> DeleteCollectionElement<T>(string endUrl, int elementId)
        {
            using (var c = new HttpClient())
            {
                HttpClient client = new HttpClient();
                var response = await client.DeleteAsync(new Uri($"{baseUrl}{endUrl}/{elementId}"));

                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return true;
                }

                return false;
            }
        }
    }
}
