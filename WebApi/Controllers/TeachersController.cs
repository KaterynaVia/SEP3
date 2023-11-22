using Application.LogicInterfaces;
using Domain;
using Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

/*
 * This controller is responsible for handling all requests to the /teachers endpoint.
 * It uses the ITeacherLogic interface to access the logic layer.
 * The controller is responsible for handling the HTTP requests and responses.
 * The controller is also responsible for mapping the DTOs to the domain models and vice versa.
 * The controller is also responsible for handling the exceptions that might occur.
 */

[ApiController]
[Route("[controller]")]
public class TeachersController : ControllerBase
{
    private readonly ITeacherLogic teacherLogic;

    public TeachersController(ITeacherLogic teacherLogic)
    {
        this.teacherLogic = teacherLogic;
    }

    [HttpPost]
    public async Task<ActionResult<Teacher>> CreateAsyncTeacher(TeacherCreationDto dto)
    {
        try
        {
            var teacher = await teacherLogic.CreateAsyncTeacher(dto);
            return Created($"/teachers/{teacher.UserId}", teacher);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Teacher>>> GetAsyncTeacher([FromQuery] string? id)
    {
        try
        {
            SearchUserParametersDto parameters = new(id);
            var teachers = await teacherLogic.GetAsyncTeacher(parameters);
            return Ok(teachers);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}