using System.Net.Http.Json;
using System.Text.Json;
using Domain;
using Domain.DTOs;
using HttpClients.ClientInterfaces;

namespace HttpClients.Implementations;

public class UserHttpClient : IUserService
{
    private readonly HttpClient client;

    public UserHttpClient(HttpClient client)
    {
        this.client = client;
    }

    public async Task<Student> CreateStudent(UserCreationDto dto)
    {
        HttpResponseMessage response = await client.PostAsJsonAsync("/students", dto);
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        Student student = JsonSerializer.Deserialize<Student>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return student;
    }

    public async Task<Teacher> CreateTeacher(UserCreationDto dto)
    {
        HttpResponseMessage response = await client.PostAsJsonAsync("/teachers", dto);
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        
        Teacher teacher = JsonSerializer.Deserialize<Teacher>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return teacher;
    }


}