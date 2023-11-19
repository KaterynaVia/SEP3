using Application.DaoInterfaces;
using Application.Logic;
using Application.LogicInterfaces;
using Domain;
using Domain.DTOs;

namespace Application.Logic;

public class UserLogic : IUserLogic
{
    private readonly IUserDao userDao;

    public UserLogic(IUserDao userDao)
    {
        this.userDao = userDao; 
    }

    public async Task<User> CreateAsync(UserCreationDto dto)
    {
        User? existing = await userDao.GetByUsernameAsync(dto.Id);
        if (existing != null)
            throw new Exception("ID not available!");

        ValidateData(dto);
        User toCreate = new User(dto.Id, dto.Password)
            {
                Id = dto.Id,
                Password = dto.Password
            }
            ;
        
        User created = await userDao.CreateAsync(toCreate);
        
        return created;
    }

    private static void ValidateData(UserCreationDto userToCreate)
    {
        int id = Convert.ToInt32(userToCreate.Id);

        if (id < 6)
            throw new Exception("Username must be at least 6 characters!");

        if (id > 8)
            throw new Exception("Username must be less than 9 characters!");
    }
    
    public Task<IEnumerable<User>> GetAsync(UserParametersDto searchParameters)
    {
        Console.WriteLine("A");
        return userDao.GetAsync(searchParameters);
    }
}