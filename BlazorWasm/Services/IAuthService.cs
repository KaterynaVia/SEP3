using System.Security.Claims;
using Domain;

namespace BlazorWasm.Services;

public interface IAuthService
{
    public Task LoginAsync(int id, string password);
    public Task LogoutAsync();
    public Task RegisterAsync(User user);
    public Task<ClaimsPrincipal> GetAuthAsync();

    public Action<ClaimsPrincipal> OnAuthStateChanged { get; set; }

    public string? Jwt { get; }
}