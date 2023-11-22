using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain;
using Domain.DTOs;

namespace Application.Logic;

/// <summary>
///  Logic for the User class
///  <para>
///  Contains all the logic for the User class
///  </para>
///  </summary>
/*
 * UserLogic is a class that implements the IUserLogic interface.
 * It is used to implement the logic for the User class.
 */

public class UserLogic : IUserLogic         // The logic to be used
{
    private readonly IUserDao userDao;      // The DAO to be used

    public UserLogic(IUserDao userDao)          // Constructor
    {
        this.userDao = userDao;
    }

    public async Task<User> CreateAsync(UserCreationDto dto)        // Creates a new User
    {
        var existing = await userDao.GetByUsernameAsync(dto.Id);        // If the id is already taken, throw an exception.
        if (existing != null)
            throw new Exception("ID not available!");

        ValidateData(dto);
        var toCreate = new User(dto.Id, dto.Password)       // If the id is not taken, validate the data and create the new User.
            {
                Id = dto.Id,
                Password = dto.Password
            }
            ;

        var created = await userDao.CreateAsync(toCreate);

        return created;
    }

    public Task<IEnumerable<User>> GetAsync(UserParametersDto searchParameters)     // gets all Users
    {
        Console.WriteLine("A");
        return userDao.GetAsync(searchParameters);
    }

    private static void ValidateData(UserCreationDto userToCreate)      // Validates the data for the User to be created. If the data is invalid, throw an exception.
    {
        var id = Convert.ToInt32(userToCreate.Id);

        if (id < 6)
            throw new Exception("Username must be at least 6 characters!");

        if (id > 8)
            throw new Exception("Username must be less than 9 characters!");
    }
}