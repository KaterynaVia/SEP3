using System.Text.Json.Serialization;

namespace Domain;

public class Exam
{
    [JsonConstructor]
    /*public Exam(int idOfExam, string nameOfExam, int grade, string dateTime)
    {
        IdOfExam = idOfExam;
        NameOfExam = nameOfExam;
        Grade = grade;
        DateTime = dateTime;
    }*/
    public Exam(int idOfExam, string nameOfExam, string dateTime)
    {
        IdOfExam = idOfExam;
        NameOfExam = nameOfExam;
        DateTime = dateTime;
    }

    public string NameOfExam { get; set; }

    //public int Grade { get; set; }
    //public Class Class { get; set; }
    public int IdOfExam { get; set; }
    public string DateTime { get; set; }
}