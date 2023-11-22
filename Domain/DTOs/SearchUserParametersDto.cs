namespace Domain.DTOs;

/// <summary>
///   DTO for search parameters for users
/// </summary>


/*
 * This DTO is used to pass search parameters to the DAO
 */

public class SearchUserParametersDto
{
    public SearchUserParametersDto(string? idContains)      // Set the ID to search for
    {
        IdContains = idContains;                // Set the ID to search for
    }

    public string? IdContains { get; }          // The ID of the user to search for 
}