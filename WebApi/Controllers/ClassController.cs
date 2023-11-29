using Application.LogicInterfaces;
using Domain;
using Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

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
    public async Task<ActionResult<Class>> CreateAsyncClass([FromBody] ClassCreationDto dto)
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


    [HttpGet]
    public async Task<ActionResult<IEnumerable<Class>>> GetAsync([FromQuery] string? className)
    {
        try
        {
            SearchClassParametersDto parameters = new(className);
            var classes = await classLogic.GetAsyncClass(parameters);
            return Ok(classes);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}