using Domain;

/*
 * Interface Purpose: Interface for the ClassDao
 * Interface for the ClassDao class in the Application Layer
 */

namespace Application.DaoInterfaces;

public interface IClassDao
{
    Task<Class> CreateAsyncClass(Class class_);
}