using Application.DaoInterfaces;
using Domain;
using Domain.DTOs;

namespace FileData.DAOs;

public class ClassFileDao : IClassDao
{
    private readonly FileContext context;
    
    public ClassFileDao(FileContext context)
    {
        this.context = context;
    }
    public Task<Class> CreateAsyncClass(Class class_)
    {
        int id = 1;
        if (context.Classes.Any())
        {
            id = context.Classes.Max(c => c.Id);
            id++;
        }

        class_.Id = id;
        
        context.Classes.Add(class_);
        context.SaveChanges();

        return Task.FromResult(class_);
    }

    public Task<IEnumerable<Class>> GetAsyncClass(SearchClassParametersDto searchClassParameters)
    {
        IEnumerable<Class> classes = context.Classes.AsEnumerable();

        return Task.FromResult(classes);
    }
}