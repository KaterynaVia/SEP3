using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain;
using Domain.DTOs;

namespace Application.Logic;

public class ExamLogic : IExamLogic
{
    private readonly IClassDao classDao;
    private readonly IExamDao examDao;

    public ExamLogic(IClassDao classDao, IExamDao examDao)
    {
        this.classDao = classDao;
        this.examDao = examDao;
    }

    public async Task<Exam> CreateAsyncExam(ExamCreationDto dto)
    {
        Class? class_ = await classDao.GetByIdClassAsync(dto.Class_.Id);
        if (class_ == null)
        {
            throw new Exception($"There is no such a class");
        }
        Exam exam = new Exam(dto.IdOfExam, dto.NameOfExam, dto.Grade, dto.DateTime, dto.Class_);
        Exam created = await examDao.CreateAsyncExam(exam);
        return created;

    }
}