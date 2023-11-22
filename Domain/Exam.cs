namespace Domain;

/*
 * Represents an exam
 */
public class Exam
{
    public DateTime Dt;

    private Exam(string nameOfExam, int grade, DateTime dt, Class class1)
    {
        NameOfExam = nameOfExam;
        Grade = grade;
        Dt = dt;
        Class = class1;
    }

    public string NameOfExam { get; set; }
    public int Grade { get; set; }
    public Class Class { get; set; }
}