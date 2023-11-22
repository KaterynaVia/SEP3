using System.Security.Claims;
using System.Text;
using System.Text.Json;
using Domain;
using Domain.DTOs;

namespace Blazor.Auth;

/// <summary>
///  Class for the JwtAuthService.
///  Implements the IAuthService interface.
///  Defines the methods for the JwtAuthService class.
/// </summary>

public class JwtAuthService : IAuthService
{
    private readonly HttpClient client = new();

    // this private variable for simple caching
    public string? Jwt { get; private set; } = "";

    public Action<ClaimsPrincipal> OnAuthStateChanged { get; set; } = null!;

    public async Task LoginAsync(string id, string password)
    {
        UserLoginDto userLoginDto = new()
        {
            Id = id,
            Password = password
        };

        var userAsJson = JsonSerializer.Serialize(userLoginDto);        // Serialize the user object to json
        StringContent content = new(userAsJson, Encoding.UTF8, "application/json");     // Create a StringContent object from the json

        var response = await client.PostAsync("https://localhost:7130/auth/login", content);        // Send the request to the server
        var responseContent = await response.Content.ReadAsStringAsync();       // Read the response from the server

        if (!response.IsSuccessStatusCode) throw new Exception(responseContent);        // If the response is not successful, throw an exception

        var token = responseContent;        // Get the token from the response
        Jwt = token;

        var principal = CreateClaimsPrincipal();

        OnAuthStateChanged.Invoke(principal);
    }

    public Task LogoutAsync()       // Logout method for the user to logout of the application and clear the token
    {
        Jwt = null;
        ClaimsPrincipal principal = new();
        OnAuthStateChanged.Invoke(principal);
        return Task.CompletedTask;
    }

    public async Task RegisterAsync(User user)      // Register method for the user to register a new account in the application
    {
        var userAsJson = JsonSerializer.Serialize(user);        // Serialize the user object to json
        StringContent content = new(userAsJson, Encoding.UTF8, "application/json");     // Create a StringContent object from the json
        var response = await client.PostAsync("https://localhost:7130/auth/register", content);       // Send the request to the server
        var responseContent = await response.Content.ReadAsStringAsync();    // Read the response from the server

        if (!response.IsSuccessStatusCode) throw new Exception(responseContent);    // If the response is not successful, throw an exception
    }

    public Task<ClaimsPrincipal> GetAuthAsync()     // GetAuthAsync method for the user to get the authentication status of the user
    {
        var principal = CreateClaimsPrincipal();    // Create a ClaimsPrincipal object
        return Task.FromResult(principal);    // Return the ClaimsPrincipal object
    }

    private ClaimsPrincipal CreateClaimsPrincipal()     // CreateClaimsPrincipal method for the user to create a ClaimsPrincipal object
    {
        if (string.IsNullOrEmpty(Jwt)) return new ClaimsPrincipal();    // If the token is null or empty, return a new ClaimsPrincipal object

        var claims = ParseClaimsFromJwt(Jwt);   // Parse the claims from the token

        ClaimsIdentity identity = new(claims, "jwt");   // Create a ClaimsIdentity object from the claims

        ClaimsPrincipal principal = new(identity);  // Create a ClaimsPrincipal object from the ClaimsIdentity object
        return principal;
    }


    // Below methods stolen from https://github.com/SteveSandersonMS/presentation-2019-06-NDCOslo/blob/master/demos/MissionControl/MissionControl.Client/Util/ServiceExtensions.cs
    private static IEnumerable<Claim> ParseClaimsFromJwt(string jwt)    // ParseClaimsFromJwt method for the user to parse the claims from the token
    {
        var payload = jwt.Split('.')[1];
        var jsonBytes = ParseBase64WithoutPadding(payload);
        var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);
        return keyValuePairs!.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString()!));
    }

    private static byte[] ParseBase64WithoutPadding(string base64)    // ParseBase64WithoutPadding method for the user to parse the base64 without padding
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
}