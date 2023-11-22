using System.Security.Claims;
using Domain;

namespace Blazor.Auth;

/// <summary>
///  Interface for the AuthService class.
///  Defines the methods that the AuthService class must implement.
/// </summary>

public interface IAuthService
{
    public Action<ClaimsPrincipal> OnAuthStateChanged { get; set; }     // This is a delegate, a function pointer

    public string? Jwt { get; }                                // The JWT token
    public Task LoginAsync(string id, string password);         // Login
    public Task LogoutAsync();                   // Logout
    public Task RegisterAsync(User user);           // Register
    public Task<ClaimsPrincipal> GetAuthAsync();            // Get the authentication state
}