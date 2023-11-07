using System.Text.Json;
using Domain;

namespace FileData;

public class FileContext
{

    private const string filePath = "data.json";
    private DataContainer? dataContainer;

    public ICollection<Teacher> Teachers
    {
        get
        {
            LoadData();
            return dataContainer!.Teachers;
        }
    }

    public ICollection<Student> Students
    {
        get
        {
            LoadData();
            return dataContainer!.Students;
        }
    }
    public ICollection<Supervisor> Supervisors
    {
        get
        {
            LoadData();
            return dataContainer!.Supervisors;
        }
    }
    public ICollection<Class> Classes
    {
        get
        {
            LoadData();
            return dataContainer!.Classes;
        }
    }
    public ICollection<Exam> Exams
    {
        get
        {
            LoadData();
            return dataContainer!.Exams;
        }
    }

    private void LoadData()
    {
        if (dataContainer != null) return;

        if (!File.Exists(filePath))
        {
            dataContainer = new ()
            {
                Teachers = new List<Teacher>(),
                Students = new List<Student>(),
                Supervisors = new List<Supervisor>(),
                Exams = new List<Exam>(),
                Classes = new List<Class>(),

            };
            return;
        }
        string content = File.ReadAllText(filePath);
        dataContainer = JsonSerializer.Deserialize<DataContainer>(content);
    }


    public void SaveChanges()
    {
        string serialized = JsonSerializer.Serialize(dataContainer, new JsonSerializerOptions
        {
            WriteIndented = true
        });
        File.WriteAllText(filePath, serialized);
        dataContainer = null;
    }
}