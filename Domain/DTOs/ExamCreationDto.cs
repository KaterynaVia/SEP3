namespace Domain.DTOs;

public class ExamCreationDto
{
    public string NameOfExam { get; }
    //public DateTime DateTime { get; }
    public int IdOfExam { get; }
   // public Class Class_ { get; }
    public int Grade { get; }

    public ExamCreationDto(string nameOfExam, int grade)
    {
        NameOfExam = nameOfExam;
        Grade = grade;
        //DateTime = dateTime;

        //IdOfExam = idOfExam;
        //Class_ = class_;
    }
    
    
}