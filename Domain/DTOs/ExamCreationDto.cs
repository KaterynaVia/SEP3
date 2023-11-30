namespace Domain.DTOs;

public class ExamCreationDto
{
    public ExamCreationDto(string nameOfExam, string dateTime)
    {
        NameOfExam = nameOfExam; 
        DateTime = dateTime;
    }

    public string NameOfExam { get; }
    
    public int IdOfExam { get; }
    
    public string DateTime { get; }
}