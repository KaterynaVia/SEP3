namespace Domain.DTOs;

public class ExamCreationDto
{
    public ExamCreationDto(string nameOfExam, int grade)
    {
        NameOfExam = nameOfExam;
        Grade = grade;
        //DateTime = dateTime;

        //IdOfExam = idOfExam;
        //Class_ = class_;
    }

    public string NameOfExam { get; }

    //public DateTime DateTime { get; }
    public int IdOfExam { get; }

    // public Class Class_ { get; }
    public int Grade { get; }
}