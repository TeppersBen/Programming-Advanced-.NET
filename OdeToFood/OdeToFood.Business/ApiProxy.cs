using System;
using System.Net.Http;

namespace OdeToFood.Business
{
    public class ApiProxy
    {
        private readonly HttpClient _httpClient;

        public ApiProxy(string baseUrl)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(baseUrl);
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<string> GetRestaurantAsync(int id)
        {
            var retaurantUrl = $"/api/Restaurants/{id}";
            HttpResponseMessage response = await _httpClient.GetAsync(restaurantUrl);
            if (response.IsSuccessStatusCode)
            {
                var restaurant = await response.Content.ReadAsByteArrayAsync<string>();
                return restaurant;
            }
            return string.Empty;
        }

        public async Task<bool> PostRestaurantAsync(Restaurant restaurant)
        {
            var restaurantUrl = $"/api/restaurants";
            var response = await _httpClient.PostAsJsonAsync(restaurantUrl, restaurant);
            return response.IsSuccessStatusCode;
        }
    }
}
