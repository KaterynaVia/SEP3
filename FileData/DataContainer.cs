using Domain;

namespace FileData;

/*
 * The data is stored in collections.
 * The collections are of type ICollection<T> where T is the type of the objects stored in the collection.
 * The collections are initialized in the constructor.
 * The collections are public so they can be accessed from other classes.
 * The collections are readonly so they can't be changed from other classes.
 * The collections are of type ICollection<T> so they can be used in the methods of the DAOs.
 */

public class DataContainer
{
    public ICollection<Teacher> Teachers { get; set; }
    public ICollection<Class> Classes { get; set; }
    public ICollection<Exam> Exams { get; set; }
    public ICollection<Student> Students { get; set; }
    public ICollection<Supervisor> Supervisors { get; set; }
}