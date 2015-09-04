using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace OssRestApi
{
    public class RestService
    {
        public T GetRestService<T>(string url, string urlParameters)
        {
            T result = default(T);
            HttpClient client = GetClient(url);

            HttpResponseMessage response = client.GetAsync(urlParameters).Result;
            if (response.IsSuccessStatusCode)
            {
                result = response.Content.ReadAsAsync<T>().Result;
            }
            return result;
        }

        public T PutRestService<T>(string url, string urlParameters, string content)
        {
            T result = default(T);
            HttpClient client = GetClient(url);

            var httpContent = new StringContent(content, Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PutAsync(urlParameters, httpContent).Result;
            if (response.IsSuccessStatusCode)
            {
                result = response.Content.ReadAsAsync<T>().Result;
            }
            return result;
        }

        public T PostRestService<T>(string url, string urlParameters, string content)
        {
            T result = default(T);
            HttpClient client = GetClient(url);

            var httpContent = new StringContent(content, Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PostAsync(urlParameters, httpContent).Result;
            if (response.IsSuccessStatusCode)
            {
                result = response.Content.ReadAsAsync<T>().Result;
            }
            return result;
        }

        public T DeleteRestService<T>(string url, string urlParameters)
        {
            T result = default(T);
            HttpClient client = GetClient(url);

            HttpResponseMessage response = client.DeleteAsync(urlParameters).Result;
            if (response.IsSuccessStatusCode)
            {
                result = response.Content.ReadAsAsync<T>().Result;
            }
            return result;
        }

        HttpClient GetClient(string url)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }
    }
}
