namespace Domain.DTOs;

public class SearchClassParametersDto
{
    public string? ClassName { get; }

    public SearchClassParametersDto(string? className)
    {
        ClassName = className;
    }
}