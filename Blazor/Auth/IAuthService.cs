using System.Security.Claims;
using Domain;

namespace Blazor.Auth;

public interface IAuthService
{
    public Task LoginAsyncStudent(string id, string password);
    public Task LoginAsyncTeacher(string id, string password);

    public Task LogoutAsync();
    
    public Action<ClaimsPrincipal> OnAuthStateChanged { get; set; }
    public Task<ClaimsPrincipal> GetAuthAsync();
}