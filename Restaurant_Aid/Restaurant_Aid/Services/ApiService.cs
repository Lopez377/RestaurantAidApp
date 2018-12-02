using Newtonsoft.Json;
using Restaurant_Aid.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Aid.Services
{
    class ApiService
    {
        string API_URL = "http://18.221.67.92/";
        HttpClient httpClient;

        public ApiService()
        {
            httpClient = new HttpClient();
        }

        public async Task<List<Restaurant>> GetRestaurants()
        {
            Uri uri = new Uri(API_URL + "restaurant");
            string temp;
            try
            {
                temp = await SendGetRequest(uri);
            }
            catch (System.Net.WebException e)
            {
                throw e;
            }
            Debug.WriteLine("Parsing JSON");
            return JsonConvert.DeserializeObject<IEnumerable<Restaurant>>(temp).ToList();
        }

        public async Task<string> SendGetRequest(Uri uri)
        {
            HttpResponseMessage response = await httpClient.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                Debug.WriteLine("Successful GET");
                return await response.Content.ReadAsStringAsync();
            }
            Debug.WriteLine("Failed GET");
            throw new System.Net.WebException();
        }
    }
}
