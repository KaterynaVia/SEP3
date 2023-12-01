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
        var response = await client.PostAsJsonAsync("/students", dto);
        var result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            var statusCode = response.StatusCode;
            Console.WriteLine(statusCode);
            throw new Exception(result);
        }

        var student = JsonSerializer.Deserialize<Student>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return student;
    }

    public async Task<Teacher> CreateTeacher(TeacherCreationDto dto)
    {
        Console.WriteLine("1");
        var response = await client.PostAsJsonAsync("/teachers", dto);
        Console.WriteLine("2");
        var result = await response.Content.ReadAsStringAsync();
        Console.WriteLine(result);
        if (!response.IsSuccessStatusCode) throw new Exception(result);


        var teacher = JsonSerializer.Deserialize<Teacher>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        Console.WriteLine($"{teacher.UserId}, {teacher.Password}, {teacher.Password}");
        return teacher;
    }

    public async Task<IEnumerable<Teacher>> GetTeachers(string? viaId = null)
    {
        var uri = "/teachers";
        if (!string.IsNullOrEmpty(viaId)) uri += $"?Id={viaId}";

        var response = await client.GetAsync(uri);
        var result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode) throw new Exception(result);

        var teachers = JsonSerializer.Deserialize<IEnumerable<Teacher>>(result,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;
        return teachers;
    }

    public async Task<IEnumerable<Student>> GetStudents(string? viaId = null)
    {
        var uri = "/students";
        if (!string.IsNullOrEmpty(viaId)) uri += $"?Id={viaId}";

        var response = await client.GetAsync(uri);
        var result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode) throw new Exception(result);

        var students = JsonSerializer.Deserialize<IEnumerable<Student>>(result,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;
        return students;
    }
}