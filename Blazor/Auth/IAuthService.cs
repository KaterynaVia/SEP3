﻿using System.Security.Claims;
using Domain;

namespace Blazor.Auth;

public interface IAuthService
{
    public Task<AuthenticationResponse> LoginAsyncStudent(string id, string password);
    public Task LoginAsyncTeacher(string id, string password);

    public Task LogoutAsync();
    
    Action<ClaimsPrincipal> OnAuthStateChanged { get; set; }
    Task<ClaimsPrincipal> GetAuthAsync();
}