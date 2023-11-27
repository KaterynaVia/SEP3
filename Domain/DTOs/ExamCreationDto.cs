namespace Domain.DTOs;

public class ExamCreationDto
{
    public string NameOfExam { get; }
    public DateTime DateTime { get; }
    public int IdOfExam { get; }
    public Class Class_ { get; }
    public int Grade { get; }

    public ExamCreationDto(int idOfExam, string nameOfExam, int grade, DateTime dateTime, Class class_)
    {
        NameOfExam = nameOfExam;
        DateTime = dateTime;

        IdOfExam = idOfExam;
        Class_ = class_;
    }
    
    
}