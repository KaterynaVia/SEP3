using Application.DaoInterfaces;
using Domain;
using Domain.DTOs;

namespace FileData.DAOs;

public class ExamFileDao : IExamDao
{
    private readonly FileContext context;
    
    
    public ExamFileDao(FileContext context)
    {
        this.context = context;
    }
    public Task<Exam> CreateAsyncExam(Exam exam)
    {
        int id = 1;
        if (context.Classes.Any())
        {
            id = context.Classes.Max(c => c.Id);
            id++;
        }

        exam.IdOfExam = id;
        
        context.Exams.Add(exam);
        context.SaveChanges();

        return Task.FromResult(exam);
    }

    public Task<Exam> GetAsyncExam(SearchExamParametersDto searchExamParameters)
    {
        IEnumerable<Exam> exams = context.Exams.AsEnumerable();
        if (searchExamParameters.ExamName != null)
        {
            exams = context.Exams.Where(e =>
                e.NameOfExam.Contains(searchExamParameters.ExamName, StringComparison.OrdinalIgnoreCase));
        }

        return Task.FromResult(exams);
    }

    public Task<Exam?> GetByNameAsyncExam(string name)
    {
        Exam? existing = context.Exams.FirstOrDefault(e =>
            e.NameOfExam.Equals(name, StringComparison.OrdinalIgnoreCase));
        return Task.FromResult(existing);
    }
}