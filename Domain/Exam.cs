using System.Text.Json.Serialization;

namespace Domain;

public class Exam
{
    public DateTime Dt = new();

    [JsonConstructor]
    /*public Exam(int idOfExam, string nameOfExam, int grade, DateTime dt, Class class1)
    {
        IdOfExam = idOfExam;
        NameOfExam = nameOfExam;
        Grade = grade;
        Dt = dt;
        Class = class1;
    }
     */
    public Exam(int idOfExam, string nameOfExam, int grade)
    {
        IdOfExam = idOfExam;
        NameOfExam = nameOfExam;
        Grade = grade;
    }

    public string NameOfExam { get; set; }
    public int Grade { get; set; }
    public Class Class { get; set; }
    public int IdOfExam { get; set; }
}