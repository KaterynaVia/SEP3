using Domain;
using Domain.DTOs;

namespace Application.DaoInterfaces;

public interface IExamDao
{
    Task<Exam> CreateAsyncExam(Exam exam);
    Task<Exam?> GetByNameAsyncExam(string name);
}