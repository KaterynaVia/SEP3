using System.Net.Http.Json;
using System.Text.Json;
using Domain;
using Domain.DTOs;
using HttpClients.ClientInterfaces;

namespace HttpClients.Implementations;

public class UserHttpClient : IUserService      // Implementation of the user service
{
    private readonly HttpClient client;

    public UserHttpClient(HttpClient client)        // Constructor for the user client
    {
        this.client = client;
    }

    public async Task<Student> CreateStudent(UserCreationDto dto)       // Create a student, returns a student object if successful or throws an exception if unsuccessful
    {
        var response = await client.PostAsJsonAsync("/students", dto);
        var result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode) throw new Exception(result);

        var student = JsonSerializer.Deserialize<Student>(result, new JsonSerializerOptions     // Deserialize the response into a student object
        {
            PropertyNameCaseInsensitive = true
        })!;
        return student;
    }

    public async Task<Teacher> CreateTeacher(UserCreationDto dto)       // Create a teacher, returns a teacher object if successful or throws an exception if unsuccessful
    {
        var response = await client.PostAsJsonAsync("/teachers", dto);
        var result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode) throw new Exception(result);


        var teacher = JsonSerializer.Deserialize<Teacher>(result, new JsonSerializerOptions     // Deserialize the response into a teacher object
        {
            PropertyNameCaseInsensitive = true
        })!;
        return teacher;
    }
}