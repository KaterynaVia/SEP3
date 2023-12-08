﻿using System.Security.Claims;
using System.Text;
using System.Text.Json;
using Domain;
using Domain.DTOs;

namespace Blazor.Auth;

public class JwtAuthService : IAuthService
{
    private readonly HttpClient client = new();
    public enum UserType
    {
        Student,
        Teacher,
        Supervisor
    }
    
    public string? Jwt { get; private set; } = "";

    public Task LogoutAsync()
    {
        Jwt = null;
        ClaimsPrincipal principal = new();
        OnAuthStateChanged.Invoke(principal);
        return Task.CompletedTask;
    }

    public Action<ClaimsPrincipal> OnAuthStateChanged { get; set; } = null!;
    public Task<ClaimsPrincipal> GetAuthAsync()
    {
        ClaimsPrincipal principal = CreateClaimsPrincipal();
        return Task.FromResult(principal);
    }

    public UserType LoggedInUserType { get; set; } = UserType.Student; // Set a default value

    public async Task LoginAsyncStudent(string id, string password)
    {
        StudentLoginDto studentLoginDto = new()
        {
            Id = id,
            Password = password
        };

        string userAsJson = JsonSerializer.Serialize(studentLoginDto);
        StringContent content = new(userAsJson, Encoding.UTF8, "application/json");

        HttpResponseMessage response = await client.PostAsync("https://localhost:7097/auth/loginStudent", content);
        string responseContent = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(responseContent);
        }

        string token = responseContent;
        Jwt = token;
        LoggedInUserType = UserType.Student; // Set the user type for student login

        ClaimsPrincipal principal = CreateClaimsPrincipal();
        OnAuthStateChanged.Invoke(principal);
    }
    
    
    
    public async Task LoginAsyncTeacher(string id, string password)
    {
        TeacherLoginDto teacherLoginDto = new()
        {
            Id = id,
            Password = password
        };

        string userAsJson = JsonSerializer.Serialize(teacherLoginDto);
        StringContent content = new(userAsJson, Encoding.UTF8, "application/json");

        HttpResponseMessage response = await client.PostAsync("https://localhost:7097/auth/loginTeacher", content);
        string responseContent = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(responseContent);
        }

        string token = responseContent;
        Jwt = token;
        LoggedInUserType = UserType.Teacher; // Set the user type for teacher login

        ClaimsPrincipal principal = CreateClaimsPrincipal();
        OnAuthStateChanged.Invoke(principal);
    }

    private static IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
    {
        string payload = jwt.Split('.')[1];
        byte[] jsonBytes = ParseBase64WithoutPadding(payload);
        Dictionary<string, object>? keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);
        return keyValuePairs!.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString()!));
    }

    private static byte[] ParseBase64WithoutPadding(string base64)
    {
        switch (base64.Length % 4)
        {
            case 2:
                base64 += "==";
                break;
            case 3:
                base64 += "=";
                break;
        }

        return Convert.FromBase64String(base64);
    }
    
    private ClaimsPrincipal CreateClaimsPrincipal()
    {
        if (string.IsNullOrEmpty(Jwt))
        {
            return new ClaimsPrincipal();
        }

        IEnumerable<Claim> claims = ParseClaimsFromJwt(Jwt);
    
        ClaimsIdentity identity = new(claims, "jwt");

        ClaimsPrincipal principal = new(identity);
        return principal;
    }
    
    
    
}