namespace Domain.DTOs;

public class SearchExamParametersDto
{
    

    public string? ExamName { get; }
    
    public SearchExamParametersDto(string? examName)
    {
        ExamName = examName;
    }
    
}