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

        public async Task<List<RMenuItem>> GetMenu(int rid)
        {
            Uri uri = new Uri(API_URL + "menu?rid=" + rid.ToString());
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
            return JsonConvert.DeserializeObject<IEnumerable<RMenuItem>>(temp).ToList();
        }

        public async Task<Profile> GetProfile(string username)
        {
            Uri uri = new Uri(API_URL + "profile?username=" + username.ToString());
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
            return JsonConvert.DeserializeObject<IEnumerable<Profile>>(temp).First();
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

        public async Task<bool> createProfile(List<KeyValuePair<string, string>> formData)
        {
            Uri uri = new Uri(API_URL + "profile");
            return await SendPostRequest(uri, formData);
        }

        public async Task<bool> SendPostRequest(Uri uri, List<KeyValuePair<string, string>> formData)
        {
            Debug.WriteLine("Sending POST request");
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, uri) {Content = new FormUrlEncodedContent(formData)};
            HttpResponseMessage response = await httpClient.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                Debug.WriteLine("Successful POST");
                return true;
            }
            return false;
        }
    }
}
