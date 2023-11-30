namespace Domain.DTOs;

public class ExamCreationDto
{
    public ExamCreationDto(string nameOfExam, int grade, string dateTime)
    {
        NameOfExam = nameOfExam;
        Grade = grade;
        DateTime = dateTime;
        //DateTime = dateTime;

        //IdOfExam = idOfExam;
        //Class_ = class_;
    }
    

    public string NameOfExam { get; }
    
    public int IdOfExam { get; }
    
    public int Grade { get; }
    public string DateTime { get; }
}