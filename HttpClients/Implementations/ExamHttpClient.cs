using System.Net.Http.Json;
using Domain.DTOs;
using HttpClients.ClientInterfaces;

namespace HttpClients.Implementations;

public class ExamHttpClient : IExamService
{
    private readonly HttpClient client;

    public ExamHttpClient(HttpClient client)
    {
        this.client = client;
    }
    
    public async Task CreateExam(ExamCreationDto dto)
    {
        HttpResponseMessage response = await client.PostAsJsonAsync("/exams", dto);
        if (!response.IsSuccessStatusCode)
        {
            var statusCode = response.StatusCode;
            Console.WriteLine(statusCode);
            string content = await response.Content.ReadAsStringAsync();
            throw new Exception(content);
        }
    }
}