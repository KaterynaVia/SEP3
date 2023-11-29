using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain;
using Domain.DTOs;

namespace Application.Logic;

public class ClassLogic : IClassLogic
{
    private readonly IClassDao classDao;
    private readonly IStudentDao studentDao;
    private readonly ITeacherDao teacherDao;
    private List<string> studentIdList;

    public ClassLogic(IClassDao classDao, IStudentDao studentDao, ITeacherDao teacherDao)
    {
        this.classDao = classDao;
        this.teacherDao = teacherDao;
        this.studentDao = studentDao;
    }

    public async Task<Class> CreateAsyncClass(ClassCreationDto dto)
    {
        var existing = await classDao.GetByIdClassAsync(dto.Id);
        if (existing != null) throw new Exception("Id already taken!");


        var toCreate = new Class(dto.Name, dto.TeacherID, dto.Id);
        //Console.WriteLine($"Student IDs for this class: {studentIdList}");
        await classDao.CreateAsyncClass(toCreate);

        return toCreate;
    }

    public Task<IEnumerable<Class>> GetAsyncClass(SearchClassParametersDto searchClassParameters)
    {
        return classDao.GetAsyncClass(searchClassParameters);
    }
}