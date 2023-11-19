using Domain;
using Domain.DTOs;

namespace Application.DaoInterfaces;

public interface IClassDao
{
    Task<Class> CreateAsyncClass(Class class_);
}