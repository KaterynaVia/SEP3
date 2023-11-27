using Domain;
using Domain.DTOs;

namespace Application.LogicInterfaces;

public interface IExamLogic
{
    Task<Exam> CreateAsyncExam(ExamCreationDto dto);
    Task<Exam> GetAsyncExam(SearchExamParametersDto searchExamParametersDto);
}