using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain;
using Domain.DTOs;

namespace Application.Logic;

/// <summary>
///   Logic for the Teacher class
///  <para>
///  Contains all the logic for the Teacher class
///  </para>
/// </summary>

/*
 * TeacherLogic is a class that implements the ITeacherLogic interface.
 * It is used to implement the logic for the Teacher class.
 */

public class TeacherLogic : ITeacherLogic
{
    private readonly ITeacherDao userDao;               // The DAO to be used
    private ITeacherLogic _teacherLogicImplementation;      // The logic to be used

    public TeacherLogic(ITeacherDao userDao)
    {
        this.userDao = userDao;
    }

    public async Task<Teacher> CreateAsyncTeacher(TeacherCreationDto dto)       // Creates a new Teacher
    {
        /*
         * If the id is already taken, throw an exception.
         * If the id is not taken, validate the data and create the new Teacher.
         */
        
        var existing = await userDao.GetByIdAsyncTeacher(dto.Id);
        if (existing != null)
            throw new Exception("Id already taken!");

        ValidateData(dto);


        var toCreate = new Teacher(dto.Id, dto.Password, dto.Name, dto.UserId);     // Create the new Teacher

        await userDao.CreateAsyncTeacher(toCreate);

        return toCreate;
    }

    public Task<IEnumerable<Teacher>> GetAsyncTeacher(SearchUserParametersDto searchParameters)    // Gets all Teachers
    {
        return userDao.GetAsyncTeacher(searchParameters);
    }


    /*
     * Validates the data for the Teacher to be created.
     * If the data is invalid, throw an exception.
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