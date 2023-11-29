using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain;
using Domain.DTOs;
using Microsoft.VisualBasic.CompilerServices;

namespace Application.Logic;

public class StudentLogic  : IStudentLogic
{
    private readonly IStudentDao userDao;

    public StudentLogic(IStudentDao userDao)
    {
        this.userDao = userDao;
    }

    public async Task<Student> CreateAsyncStudent(StudentCreationDto dto)
    {
        Student? existing = await userDao.GetByIdAsync(dto.Id);
        if (existing != null)
        {
            throw new Exception("Id already taken!");
        }
            

        ValidateData(dto);
        
        
        Student toCreate = new Student(dto.Id, dto.Password, dto.Name, dto.AssignedClass);
        await userDao.CreateAsyncStudent(toCreate);
        return toCreate;
    }

    public Task<IEnumerable<Student>> GetAsyncStudent(SearchUserParametersDto searchParameters)
    {
        return userDao.GetAsyncStudent(searchParameters);
    }
    

    private static void ValidateData(UserCreationDto userToCreate)
    {
        string id = userToCreate.Id;

        if (id.Length != 6)
            throw new Exception("VIA ID must be 6 characters!");

        string password = userToCreate.Password;

        if (password.Length < 7) throw new Exception("Password must be at least 8 characters. ");

    }
}