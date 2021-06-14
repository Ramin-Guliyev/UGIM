using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UGIM.WebUI.Models;

namespace UGIM.WebUI.Services
{
    public class AuthService
    {
        private readonly string _baseUrl;

        public AuthService(string baseUrl)
        {
            _baseUrl = baseUrl;
        }

        public async Task<UserManagerResponse> LoginAsync(LoginViewModel model)
        {
            using (HttpClient client =new HttpClient())
            {
                string jsonData = JsonConvert.SerializeObject(model);
                HttpContent content = new StringContent(jsonData);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = await client.PostAsync($"{_baseUrl}/api/auth/login", content);
                var responseAsString = await response.Content.ReadAsStringAsync();
                UserManagerResponse obj = JsonConvert.DeserializeObject<UserManagerResponse>(responseAsString);
                return obj;
            }
        }
        public async Task<UserManagerResponse> ForgotPasswordAsync(string model)
        {
            using (HttpClient client = new HttpClient())
            {
                string jsonData = JsonConvert.SerializeObject(model);
                HttpContent content = new StringContent(jsonData);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = await client.PostAsync($"{_baseUrl}/api/auth/forgetpassword", content);
                var responseAsString = await response.Content.ReadAsStringAsync();
                UserManagerResponse obj = JsonConvert.DeserializeObject<UserManagerResponse>(responseAsString);
                return obj;
            }
        }
    }
}
