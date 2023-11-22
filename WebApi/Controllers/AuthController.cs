using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Domain;
using Domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WebApi.Services;

namespace WebAPI.Controllers;

/// <summary>
///   This controller is used to register and login users
///  It is not used in the current version of the project
/// </summary>

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase        // Controller for the authentication of users
{
    private readonly IAuthService authService;          // Service for the authentication of users
    private readonly IConfiguration config;         // Configuration for the authentication of users

    public AuthController(IConfiguration config, IAuthService authService)          // Constructor for the authentication controller
    {
        this.config = config;       // Inject the configuration
        this.authService = authService;         // Inject the authentication service
    }

    [HttpPost]
    [Route("register")]         // Register a user
    public async Task<ActionResult> Register([FromBody] User user)          // Register a user, returns an ok status code if successful or a bad request status code if unsuccessful
    {
        await authService.RegisterUser(user);       // Register the user
        return Ok();            // Return an ok status code
    }

    [HttpPost]
    [Route("login")]            // Login a user
    public async Task<ActionResult> Login([FromBody] UserLoginDto userLoginDto)         // Login a user, returns a token if successful or a bad request status code if unsuccessful
    {
        try        // Try to login the user
        {
            var user = await authService.ValidateUser(userLoginDto.Id, userLoginDto.Password);
            var token = GenerateJwt(user);

            return Ok(token);
        }
        catch (Exception e)        // Catch any exceptions
        {
            return BadRequest(e.Message);
        }
    }

    private string GenerateJwt(User user)       // Generate a JWT token for a user
    {
        var claims = GenerateClaims(user);      // Generate the claims for the user

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));      // Generate the key for the token
        var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);        // Generate the signing credentials for the token

        var header = new JwtHeader(signIn);     // Generate the header for the token

        var payload = new JwtPayload(
            config["Jwt:Issuer"],
            config["Jwt:Audience"],
            claims,
            null,
            DateTime.UtcNow.AddMinutes(60));

        var token = new JwtSecurityToken(header, payload);      // Generate the token

        var serializedToken = new JwtSecurityTokenHandler().WriteToken(token);      // Serialize the token
        return serializedToken;
    }

    private List<Claim> GenerateClaims(User user)       // Generate the claims for a user to be used in the token
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, config["Jwt:Subject"]),    // Generate the claims
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),     // Generate the claims
            new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),     // Generate the claims
            new Claim(ClaimTypes.Name, user.Id)
        };
        return claims.ToList();     // Return the claims
    }
}