using System.Security.Claims;
using Domain;

namespace Blazor.Auth;

public interface IAuthService
{
    public Action<ClaimsPrincipal> OnAuthStateChanged { get; set; }

    public string? Jwt { get; }
    public Task LoginAsync(string id, string password);
    public Task LogoutAsync();
    public Task RegisterAsync(User user);
    public Task<ClaimsPrincipal> GetAuthAsync();
}