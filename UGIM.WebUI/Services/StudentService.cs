using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Newtonsoft.Json;
using UGIM.WebUI.Models;

namespace UGIM.WebUI.Services
{
    public class StudentService
    {
        private readonly string _baseUrl;

        public StudentService(string baseUrl)
        {
            _baseUrl = baseUrl;
        }

        public async Task<StudentResponse> AddStudentAsync(StudentAddModel model,string accessToken)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",accessToken);
                string jsonData = JsonConvert.SerializeObject(model);
                HttpContent content = new StringContent(jsonData);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = await client.PostAsync($"{_baseUrl}/api/students", content);
                var responseAsString = await response.Content.ReadAsStringAsync();
                StudentResponse obj = JsonConvert.DeserializeObject<StudentResponse>(responseAsString);
                return obj;
            }
        }
        public async Task<StudentDataResponse<IEnumerable<StudentAddModel>>> GetStudentAsync(string accessToken)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                var response = await client.GetAsync($"{_baseUrl}/api/students/getall");
                var responseAsString = await response.Content.ReadAsStringAsync();
                StudentDataResponse<IEnumerable<StudentAddModel>> obj = JsonConvert.DeserializeObject<StudentDataResponse<IEnumerable<StudentAddModel>>>(responseAsString);
                return obj;
            }
        }

        public async Task<StudentResponse>DeleteAsync(int id, string accessToken)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                var response = await client.DeleteAsync($"{_baseUrl}/api/students?id={id}");
                var responseAsString = await response.Content.ReadAsStringAsync();
                StudentResponse obj = JsonConvert.DeserializeObject<StudentResponse>(responseAsString);
                return obj;
            }
        }

        public async Task<StudentResponse> UpdateStudentAsync(StudentAddModel model, string accessToken)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                string jsonData = JsonConvert.SerializeObject(model);
                HttpContent content = new StringContent(jsonData);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = await client.PutAsync($"{_baseUrl}/api/students", content);
                var responseAsString = await response.Content.ReadAsStringAsync();
                StudentResponse obj = JsonConvert.DeserializeObject<StudentResponse>(responseAsString);
                return obj;
            }
        }
        public async Task<StudentDataResponse<StudentAddModel>>GetByIdAsync(int id,string accessToken)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                var response = await client.GetAsync($"{_baseUrl}/api/students/{id}");
                var responseAsString = await response.Content.ReadAsStringAsync();
                StudentDataResponse<StudentAddModel> obj = JsonConvert.DeserializeObject<StudentDataResponse<StudentAddModel>>(responseAsString);
                return obj;
            }
        }
    }
}
