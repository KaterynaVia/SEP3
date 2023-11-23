using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain;
using Domain.DTOs;
using Microsoft.VisualBasic.CompilerServices;

namespace Application.Logic;

public class ClassLogic : IClassLogic
{
    private readonly IClassLogic classDao;
    private readonly ITeacherDao teacherDao;
    private readonly IStudentDao studentDao;
    private List<string> studentIdList;

    public ClassLogic(IClassLogic classDao, IStudentDao studentDao, ITeacherDao teacherDao)
    {
        this.classDao = classDao;
        this.teacherDao = teacherDao;
        this.studentDao = studentDao;
    }
    public async Task<Class> CreateAsyncClass(ClassCreationDto dto)
    {
        Teacher? teacher = await teacherDao.GetByIdAsyncTeacher(dto.TeacherID.Id);
        if (teacher == null)
        {
            throw new Exception($"Teacher with id {dto.TeacherID.Id} was not found.");
        }

        List<Student> students = dto.Students;
        if (students == null)
        {
            throw new Exception("No students in the list.");
        }

        
        foreach (var student in students)
        {
            studentIdList.Add(student.Id);
        }
        
        Class class_ = new Class(teacher, students, "TestClass");
        Console.WriteLine($"Student IDs for this class: {studentIdList}");

        return class_;

    }

    public Task<IEnumerable<Class>> GetAsyncClass(SearchClassParametersDto searchClassParameters)
    {
        return classDao.GetAsyncClass(searchClassParameters);
    }
}