using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace School.Business
{
    public class ApiProxy
    {
        private HttpClient _httpClient;

        public ApiProxy(string baseUrl)
        {
            _httpClient = new HttpClient {BaseAddress = new Uri(baseUrl)};
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<string> GetCourseDepartmentAsync(int courseId)
        {
            var departmentUrl = $"/api/courses/{courseId}/department";
            HttpResponseMessage response = await _httpClient.GetAsync(departmentUrl);
            if (response.IsSuccessStatusCode)
            {
                var department = await response.Content.ReadAsAsync<string>();
                return department;
            }
            return string.Empty;
        }
    }
}
