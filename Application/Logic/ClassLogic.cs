using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain;
using Domain.DTOs;

namespace Application.Logic;

/*
 * ClassLogic is the logic layer for the Class entity.
 * It is responsible for handling the business logic for the Class entity.
 * It is used by the ClassController.
 */

public class ClassLogic : IClassLogic                 // ClassLogic implements the IClassLogic interface.
{
    private readonly IClassLogic classDao;          // classDao is an instance of the IClassDao interface.
    private readonly IStudentDao studentDao;        // studentDao is an instance of the IStudentDao interface.
    private readonly ITeacherDao teacherDao;
    private List<string> studentIdList;

    public ClassLogic(IClassLogic classDao, IStudentDao studentDao, ITeacherDao teacherDao)     // ClassLogic constructor, which takes an instance of the IClassDao interface as a parameter.
    {
        this.classDao = classDao;           // classDao is set to the instance of the IClassDao interface that was passed in.
        this.teacherDao = teacherDao;
        this.studentDao = studentDao;
    }

    public async Task<Class> CreateAsyncClass(ClassCreationDto dto)     // CreateAsyncClass is a method that takes a ClassCreationDto as a parameter and returns a Task of Class   
    {
        var teacher = await teacherDao.GetByIdAsyncTeacher(dto.Teacher.Id);
        if (teacher == null) throw new Exception($"Teacher with id {dto.Teacher.Id} was not found.");

        var students = dto.Students;
        if (students == null) throw new Exception("No students in the list.");


        foreach (var student in students) studentIdList.Add(student.Id);

        var class_ = new Class(teacher, students, "TestClass");
        Console.WriteLine($"Student IDs for this class: {studentIdList}");

        return class_;
    }
}