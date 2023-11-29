namespace Domain.DTOs;

public class SearchExamParametersDto
{
    public SearchExamParametersDto(string? examName)
    {
        ExamName = examName;
    }


    public string? ExamName { get; }
}