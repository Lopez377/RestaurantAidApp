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

        public async Task<Restaurant> GetSingleRestaurant(string rid)
        {
            Uri uri = new Uri(API_URL + "restaurant?id=" + rid);
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
            return JsonConvert.DeserializeObject<IEnumerable<Restaurant>>(temp).ToList().First();
        }

        public async Task<Restaurant> GetSingleRestaurantByUsername(string username)
        {
            Uri uri = new Uri(API_URL + "restaurant?username=" + username);
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
            return JsonConvert.DeserializeObject<IEnumerable<Restaurant>>(temp).ToList().First();
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

        public async Task<RMenuItem> GetMenuItem(string id)
        {
            Uri uri = new Uri(API_URL + "menu?id=" + id);
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
            return JsonConvert.DeserializeObject<IEnumerable<RMenuItem>>(temp).ToList().First();
        }

        public async Task<List<Order>> GetOrdersForProfile(int pid)
        {
            Uri uri = new Uri(API_URL + "order?pid=" + pid.ToString());
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
            return JsonConvert.DeserializeObject<IEnumerable<Order>>(temp).ToList();
        }


        public async Task<List<Order>> GetOrdersForRestaurant(int rid)
        {
            Uri uri = new Uri(API_URL + "order?rid=" + rid.ToString());
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
            return JsonConvert.DeserializeObject<IEnumerable<Order>>(temp).ToList();
        }

        public async Task<List<Alert>> GetAlertsByRid(string rid)
        {
            Uri uri = new Uri(API_URL + "alert?rid=" + rid);
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
            return JsonConvert.DeserializeObject<IEnumerable<Alert>>(temp).ToList();
        }

        public async Task<Alert> GetSingleAlert(string id)
        {
            Uri uri = new Uri(API_URL + "alert?id=" + id);
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
            return JsonConvert.DeserializeObject<IEnumerable<Alert>>(temp).ToList().First();
        }

        public async Task<List<Order>> GetSingleOrder(string oid)
        {
            Uri uri = new Uri(API_URL + "order?id=" + oid);
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
            return JsonConvert.DeserializeObject<IEnumerable<Order>>(temp).ToList();
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

        public async Task<bool> createMenuItem(List<KeyValuePair<string, string>> formData)
        {
            Uri uri = new Uri(API_URL + "menu");
            return await SendPostRequest(uri, formData);
        }

        public async Task<bool> createOrder(List<KeyValuePair<string, string>> formData)
        {
            Uri uri = new Uri(API_URL + "order");
            return await SendPostRequest(uri, formData);
        }

        public async Task<bool> createRestaurant(List<KeyValuePair<string, string>> formData)
        {
            Uri uri = new Uri(API_URL + "restaurant");
            return await SendPostRequest(uri, formData);
        }

        public async Task<bool> sendAlert(List<KeyValuePair<string, string>> formData)
        {
            Uri uri = new Uri(API_URL + "alert");
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

        public async Task<bool> editRestaurant(string rid, List<KeyValuePair<string, string>> formData)
        {
            Uri uri = new Uri(API_URL + "restaurant?id=" + rid);
            return await SendPutRequest(uri, formData);
        }

        public async Task<bool> editMenuItem(string rid, List<KeyValuePair<string, string>> formData)
        {
            Uri uri = new Uri(API_URL + "menu?id=" + rid);
            return await SendPutRequest(uri, formData);
        }

        public async Task<bool> editAlertStatus(string id, List<KeyValuePair<string, string>> formData)
        {
            Uri uri = new Uri(API_URL + "alert?id=" + id);
            return await SendPutRequest(uri, formData);
        }

        public async Task<bool> editOrderStatus(string id, List<KeyValuePair<string, string>> formData)
        {
            Uri uri = new Uri(API_URL + "order?id=" + id);
            return await SendPutRequest(uri, formData);
        }

        public async Task<bool> SendPutRequest(Uri uri, List<KeyValuePair<string, string>> formData)
        {
            Debug.WriteLine("Sending PUT request");
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put, uri) { Content = new FormUrlEncodedContent(formData) };
            HttpResponseMessage response = await httpClient.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                Debug.WriteLine("Successful PUT");
                return true;
            }
            return false;
        }

        public async Task<bool> deleteAlert(string id)
        {
            Uri uri = new Uri(API_URL + "alert?id=" + id);
            return await SendDeleteRequest(uri);
        }

        public async Task<bool> deleteMenuItem(string id)
        {
            Uri uri = new Uri(API_URL + "menu?id=" + id);
            return await SendDeleteRequest(uri);
        }

        public async Task<bool> deleteOrder(string id)
        {
            Uri uri = new Uri(API_URL + "order?id=" + id);
            return await SendDeleteRequest(uri);
        }

        public async Task<bool> SendDeleteRequest(Uri uri)
        {
            Debug.WriteLine("Sending DELETE request");
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Delete, uri);
            HttpResponseMessage response = await httpClient.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                Debug.WriteLine("Successful DELETE");
                return true;
            }
            return false;
        }
    }
}
