using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blazor.Pages;

/// <summary>
///   Error page
///  <para>Path: /Error</para>
/// </summary>


/*
 * This page is used to display errors
 */

[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
[IgnoreAntiforgeryToken]
public class ErrorModel : PageModel
{
    /*
     * RequestId is used to display the error message
     * <para>RequestId is set in the OnGet method</para>
     * <para>RequestId is displayed in the Error.cshtml page</para>
     */
    private readonly ILogger<ErrorModel> _logger;

    public ErrorModel(ILogger<ErrorModel> logger)       // ILogger is used to log errors
    {
        _logger = logger;
    }

    public string? RequestId { get; set; }

    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);    // ShowRequestId is used to display the error message

    public void OnGet()     // OnGet is called when the page is loaded
    {
        RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
    }
}