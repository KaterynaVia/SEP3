namespace Domain;

public class Exam
{
    public string NameOfExam { get; set; }
    public int Grade { get; set; }
    public DateTime Dt = new DateTime();
    public Class Class { get; set; }
    public int IdOfExam { get; set; }

    public Exam(int idOfExam, string nameOfExam, int grade, DateTime dt, Class class1)
    {
        IdOfExam = idOfExam;
        NameOfExam = nameOfExam;
        Grade = grade;
        Dt = dt;
        Class = class1;
    }
}