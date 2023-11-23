using Domain;

namespace FileData;

public class DataContainer
{
    public ICollection<Teacher> Teachers { get; set; }
    public ICollection<Class> Classes { get; set; }
    public ICollection<Exam> Exams { get; set; }
    public ICollection<Student> Students { get; set; }
    public ICollection<Supervisor> Supervisors { get; set; } 
}