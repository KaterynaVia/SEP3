using Domain.DTOs;

namespace HttpClients.ClientInterfaces;

public interface IExamService
{
    Task CreateExam(ExamCreationDto dto);
}