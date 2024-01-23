using Newtonsoft.Json;
using StudentCrud.Models.Model;
using StudentCrud.Services.Interface;
using StudentCrud.Services.Url;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace StudentCrud.Services.Service
{
    public class StudentService : IStudentInterface
    {
        private readonly HttpClient _httpClient;

        private readonly string _createUrl = ServiceUrl.CreateUrl;
        private readonly string _deleteUrl = ServiceUrl.DeleteUrl;
        private readonly string _getByIdUrl = ServiceUrl.GetByIdUrl;
        private readonly string _getStudentUrl = ServiceUrl.GetStudentUrl;
        private readonly string _updateUrl = ServiceUrl.UpdateUrl;

        public StudentService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<StudentModel> Create(StudentModel student)
        {
            try
            {
                // Send an HTTP POST request to the specified API endpoint with the provided StateDto as JSON.
                HttpResponseMessage response = await _httpClient.PostAsJsonAsync(_createUrl, student);

                // Ensure that the HTTP request was successful (status code 2xx).
                response.EnsureSuccessStatusCode();

                // Read the response content as a string.
                string responseBody = await response.Content.ReadAsStringAsync();

                // Deserialize the JSON response into a StateDto object.
                return JsonConvert.DeserializeObject<StudentModel>(responseBody);
            }
            catch (HttpRequestException ex)
            {
                // Catch and rethrow any HttpRequestException, providing a more specific error message.
                throw new HttpRequestException($"HTTP request error: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Catch and rethrow any other exception type, providing a more generic error message.
                throw new Exception($"Exception: {ex.Message}");
            }
        }

        public async Task<StudentModel> Delete(int id)
        {
            
                try
                {
                    // Send an HTTP DELETE request to the specified API endpoint with the provided id in the URL.
                    HttpResponseMessage response = await _httpClient.DeleteAsync($"{_deleteUrl}/Delete?Id={id}");

                    // Check if the response indicates a failure (non-success status code)
                    if (!response.IsSuccessStatusCode)
                    {
                        // If the status code is 404 (Not Found), handle it appropriately
                        if (response.StatusCode == HttpStatusCode.NotFound)
                        {
                            // Handle 404 Not Found
                            // You can return null or throw a custom exception, or handle it according to your application's logic
                            return null;
                        }

                        // Handle other non-success status codes if needed
                        // For example, you might throw a custom exception with details from the response
                        throw new HttpRequestException($"HTTP request error: {response.StatusCode} - {response.ReasonPhrase}");
                    }

                    // Read the response content as a string.
                    string responseBody = await response.Content.ReadAsStringAsync();

                    // Deserialize the JSON response into a StateDto object.
                    return JsonConvert.DeserializeObject<StudentModel>(responseBody);
                }
                catch (HttpRequestException ex)
                {
                    // Catch and rethrow any HttpRequestException, providing a more specific error message.
                    throw new HttpRequestException($"HTTP request error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    // Catch and rethrow any other exception type, providing a more generic error message.
                    throw new Exception($"Exception: {ex.Message}");
                }
            

        }

        public async Task<StudentModel> GetById(int id)
        {
           
                try
                {
                    HttpResponseMessage response = await _httpClient.GetAsync($"{_getByIdUrl}/{id}");

                    response.EnsureSuccessStatusCode();

                    string responseBody = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<StudentModel>(responseBody);
                }
                catch (HttpRequestException ex)
                {
                    throw new HttpRequestException($"HTTP request error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    throw new Exception($"Exception: {ex.Message}");
                }
            

        }

        public async Task<IEnumerable<StudentModel>> GetStudents()
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(_getStudentUrl);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();

                    try
                    {
                        // Deserialize the JSON array to a list of StudentModel
                        var dtos = JsonConvert.DeserializeObject<List<StudentModel>>(responseBody);
                        return dtos ?? new List<StudentModel>();
                    }
                    catch (JsonSerializationException)
                    {
                        // If deserialization as a list fails, try deserializing as a single object
                        var dto = JsonConvert.DeserializeObject<StudentModel>(responseBody);
                        return dto != null ? new List<StudentModel> { dto } : new List<StudentModel>();
                    }
                }
                else
                {
                    // Handle non-success status codes
                    string errorResponse = await response.Content.ReadAsStringAsync();
                    throw new HttpRequestException($"Error: {response.StatusCode}. Response: {errorResponse}");
                }
            }
            catch (HttpRequestException ex)
            {
                // Handle general HttpRequestException
                throw new HttpRequestException($"HTTP request error: {ex.Message}. URL: {_getStudentUrl}", ex);
            }
            catch (Exception ex)
            {
                // Handle general exceptions
                throw new Exception($"Exception: {ex.Message}. URL: {_getStudentUrl}", ex);
            }
        }

        public async Task<StudentModel> Update(int id, StudentModel student)
        {
           
                try
                {
                    // Commented out token retrieval and usage (JWT authentication)
                    // string token = _httpContextAccessor.HttpContext.Request.Cookies["Token"];
                    // if (string.IsNullOrEmpty(token))
                    // {
                    //     throw new Exception("Token not found or invalid.");
                    // }
                    // _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    // Send an HTTP PUT request to the specified API endpoint with the provided id in the URL
                    // and the updatedStateDto as JSON in the request body.
                    HttpResponseMessage response = await _httpClient.PutAsJsonAsync($"{_updateUrl}/{id}", student);

                    // Ensure that the HTTP request was successful (status code 2xx).
                    response.EnsureSuccessStatusCode();

                    // Read the response content as a string.
                    string responseBody = await response.Content.ReadAsStringAsync();

                    // Deserialize the JSON response into a StateDto object.
                    return JsonConvert.DeserializeObject<StudentModel>(responseBody);
                }
                catch (HttpRequestException ex)
                {
                    // Catch and rethrow any HttpRequestException, providing a more specific error message.
                    throw new HttpRequestException($"HTTP request error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    // Catch and rethrow any other exception type, providing a more generic error message.
                    throw new Exception($"Exception: {ex.Message}");
                }
        }

        
    }
}
