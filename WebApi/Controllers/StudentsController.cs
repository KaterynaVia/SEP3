using Application.LogicInterfaces;
using Domain;
using Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

/*
 * This controller is responsible for handling all requests to the /students endpoint.
 * It uses the IStudentLogic interface to access the logic layer.
 * The controller is responsible for handling the HTTP requests and responses.
 * The controller is also responsible for mapping the DTOs to the domain models and vice versa.
 * The controller is also responsible for handling the exceptions that might occur.
 */

[ApiController]
[Route("[controller]")]
public class StudentsController : ControllerBase
{
    private readonly IStudentLogic studentLogic;        // The logic layer interface

    public StudentsController(IStudentLogic studentLogic)       // The constructor for dependency injection of the logic layer interface
    {
        this.studentLogic = studentLogic;
    }

    [HttpPost]
    public async Task<ActionResult<Student>> CreateAsyncStudent(StudentCreationDto dto)    // The method for handling the POST request to create a new student
    {
        try
        {
            var student = await studentLogic.CreateAsyncStudent(dto);       // The logic layer method is called to create a new student
            return Created($"/students/{student.UserId}", student);     // The student is returned in the response body
        }
        catch (Exception e)         // If an exception occurs, the exception is caught and a 500 Internal Server Error is returned
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<Student>>> GetAsyncStudent([FromQuery] string? userId)   // The method for handling the GET request to get a student
    {
        try
        {
            SearchUserParametersDto parameters = new(userId);       // The parameters are mapped from the query string to a DTO
            var students = await studentLogic.GetAsyncStudent(parameters);      // The logic layer method is called to get a student
            return Ok(students);        // The student is returned in the response body
        }
        catch (Exception e)     // If an exception occurs, the exception is caught and a 500 Internal Server Error is returned
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}