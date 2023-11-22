using Application.DaoInterfaces;
using Domain;

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
}