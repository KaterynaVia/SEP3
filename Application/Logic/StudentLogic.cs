using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain;
using Domain.DTOs;

namespace Application.Logic;

/*
 * This class is responsible for handling the logic of the Student entity.
 * It is used by the StudentController.
 * It uses the IStudentDao interface to access the database.
 */

public class StudentLogic : IStudentLogic
{
    private readonly IStudentDao userDao;

    public StudentLogic(IStudentDao userDao) // Dependency Injection    
    {
        this.userDao = userDao;     // The userDao is injected into the constructor.
    }

    public async Task<Student> CreateAsyncStudent(StudentCreationDto dto)
    {
        /*
         * The method checks if the id is already taken.
         */
        
        Console.WriteLine("2");
        var existing = await userDao.GetByIdAsync(dto.Id);
        if (existing != null) throw new Exception("Id already taken!");


        ValidateData(dto);


        var toCreate = new Student(dto.Id, dto.Password, dto.Name, dto.UserId, dto.AssignedClass);   // The Student object is created.
        await userDao.CreateAsyncStudent(toCreate);     // The Student object is passed to the userDao.
        return toCreate;
    }

    public Task<IEnumerable<Student>> GetAsyncStudent(SearchUserParametersDto searchParameters)     // The method returns a list of students.
    {
        return userDao.GetAsyncStudent(searchParameters);
    }

    
    /*
     * This method checks if the data is valid.
     * If not, an exception is thrown.
     */
    private static void ValidateData(UserCreationDto userToCreate)
    {
        var id = userToCreate.Id;

        if (id.Length != 6)
            throw new Exception("VIA ID must be 6 characters!");

        var password = userToCreate.Password;

        if (password.Length < 8) throw new Exception("Password must be at least 8 characters. ");
    }
}