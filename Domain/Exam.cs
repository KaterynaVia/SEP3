namespace Domain;

public class Exam
{
    
    public string NameOfExam { get; set; }
    public int Grade { get; set; }
    public DateTime Dt = new DateTime();
    public Class Class { get; set; }

    Exam(string nameOfExam, int grade, DateTime dt, Class class1)
    {
        NameOfExam = nameOfExam;
        Grade = grade;
        Dt = dt;
        Class = class1;
    }  
}