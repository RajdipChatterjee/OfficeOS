using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace OfficeOS.Api.Controllers.Base;

/// <summary>
/// Provides shared HTTP-related functionality for OfficeOS API controllers.
/// </summary>
[ApiController]
public abstract class ApiControllerBase : ControllerBase
{
    /// <summary>
    /// Retrieves the remote IP address associated with the current HTTP connection.
    /// </summary>
    protected IPAddress? RemoteIpAddress()
    {
        return HttpContext.Connection.RemoteIpAddress;
    }

    /// <summary>
    /// Retrieves the User-Agent header from the current HTTP request.
    /// </summary>
    protected string? GetUserAgent
    {
        get 
        {
            var value = Request.Headers.UserAgent.ToString();
            return string.IsNullOrWhiteSpace(value) ? null : value;
        }
    }

    /// <summary>
    /// Gets the cancellation token associated with the current HTTP request.
    /// </summary>
    protected CancellationToken RequestCancellationToken =>
        HttpContext.RequestAborted;

    /// <summary>
    /// Gets the current distributed trace identifier.
    /// Falls back to the ASP.NET Core request identifier.
    /// </summary>
    protected string RequestTraceId =>
        Activity.Current?.TraceId.ToString() is { Length: > 0 } traceId 
        ? traceId 
        : HttpContext.TraceIdentifier;
}
