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

    public async Task<Student> CreateStudent(StudentCreationDto dto)
    {
        HttpResponseMessage response = await client.PostAsJsonAsync("/students", dto);
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            var statusCode = response.StatusCode;
            Console.WriteLine(statusCode);
            throw new Exception(result);
        }

        Student student = JsonSerializer.Deserialize<Student>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return student;
    }

    public async Task<Teacher> CreateTeacher(TeacherCreationDto dto)
    {
        Console.WriteLine("1");
        HttpResponseMessage response = await client.PostAsJsonAsync("/teachers", dto);
        Console.WriteLine("2");
        string result = await response.Content.ReadAsStringAsync();
        Console.WriteLine(result);
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        
        Teacher teacher = JsonSerializer.Deserialize<Teacher>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        Console.WriteLine($"{teacher.UserId}, {teacher.Password}, {teacher.Password}");
        return teacher;
    }


}