using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class AccessController : ControllerBase
{
    // policy MustBeVia
    [HttpGet("mustbevia")]
    [Authorize("MustBeVia")]
    public ActionResult GetAsVia()
    {
        return Ok("This was accepted as via domain");
    }
    
    // manual checking
    [HttpGet("manualcheck")]
    public ActionResult GetWithManualCheck()
    {
        var claim = User.Claims.FirstOrDefault(claim => claim.Type.Equals(ClaimTypes.Role));
        if (claim == null) return StatusCode(403, "You have no role");
        
        string role = claim.Value;

        return role switch
        {
            // Check for the three different roles
            "Teacher" => Ok("You are a teacher, you may proceed"),
            "Student" => Ok("You are a student, you may proceed"),
           // "Supervisor" => Ok("You are a supervisor, you may proceed"),
            _ => StatusCode(403, "Invalid role")
        };
    }
}