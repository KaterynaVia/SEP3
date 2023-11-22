using System.Text.Json;
using Domain;

namespace FileData;

/*
 * the class is used to access the data in the file 
 */

public class FileContext            
{
    private const string filePath = "data.json";        // The path to the file where the data is stored
    private DataContainer? dataContainer;        // The data container where the data is stored

    public ICollection<Teacher> Teachers        // The collection of teachers
    {
        get
        {
            LoadData();
            return dataContainer!.Teachers;
        }
    }

    public ICollection<Student> Students        // The collection of students
    {
        get
        {
            LoadData();
            return dataContainer!.Students;
        }
    }

    public ICollection<Supervisor> Supervisors      // The collection of supervisors
    {
        get
        {
            LoadData();
            return dataContainer!.Supervisors;
        }
    }

    public ICollection<Class> Classes       // The collection of classes
    {
        get
        {
            LoadData();
            return dataContainer!.Classes;
        }
    }

    public ICollection<Exam> Exams          // The collection of exams
    {
        get
        {
            LoadData();
            return dataContainer!.Exams;
        }
    }

    private void LoadData()
    {
        /*
         * This method loads the data from the file into the data container.
         * If the data container is null it creates a new data container.
         * If the file doesn't exist it creates a new data container.
         * If the file exists it reads the content of the file and deserializes it into the data container.
         */
        
        if (dataContainer != null) return;

        if (!File.Exists(filePath))
        {
            dataContainer = new DataContainer
            {
                Teachers = new List<Teacher>(),
                Students = new List<Student>(),
                Supervisors = new List<Supervisor>(),
                Exams = new List<Exam>(),
                Classes = new List<Class>()
            };
            return;
        }

        var content = File.ReadAllText(filePath);
        dataContainer = JsonSerializer.Deserialize<DataContainer>(content);
    }


    public void SaveChanges()
    {
        
        /*
         * This method saves the data from the data container into the file.
         * If the data container is null it does nothing.
         * If the data container is not null it serializes the data container into a string.
         */
        var serialized = JsonSerializer.Serialize(dataContainer, new JsonSerializerOptions
        {
            WriteIndented = true
        });
        File.WriteAllText(filePath, serialized);
        dataContainer = null;
    }
}