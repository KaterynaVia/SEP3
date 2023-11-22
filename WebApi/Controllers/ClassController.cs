using Application.LogicInterfaces;
using Domain;
using Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

/*
 * Controller for the class entity
 * Contains methods for creating a class
 */

[ApiController]
[Route("[controller]")]
public class ClassController : ControllerBase
{
    private readonly IClassLogic classLogic;

    public ClassController(IClassLogic classLogic)
    {
        this.classLogic = classLogic;
    }


    [HttpPost]
    public async Task<ActionResult<Class>> CreateAsyncClass([FromBody] ClassCreationDto dto)    // Create a class, returns a class object if successful or throws an exception if unsuccessful
    {
        try
        {
            var created = await classLogic.CreateAsyncClass(dto);
            return Created($"/classes/{created.Id}", created);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}