using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace OfficeOS.Api.Controllers.Base;

/// <summary>
/// Provides shared HTTP-related functionality for OfficeOS API controllers.
/// 
/// This class serves as a common foundation for API controllers,
/// reducing duplication and establishing consistent controller conventions.
/// </summary>
/// <remarks>
/// ARCHITECTURAL RESPONSIBILITIES
///
/// 1. Request Metadata
///    - Remote IP address
///    - User-Agent
///    - Correlation ID
///    - Request cancellation
///
/// 2. Current User Context
///    - Authenticated user identity
///    - User claims
///
/// 3. Tenant Context
///    - Current organization
///    - Current practice
///    - Tenant-specific context
///
/// 4. API Conventions
///    - Consistent validation behavior
///    - Standardized response conventions
///
/// ARCHITECTURAL BOUNDARIES
///
/// Not every responsibility listed above belongs directly in this class.
/// This class should primarily contain HTTP/controller-specific functionality.
///
/// Tenant resolution, authorization, identity management,
/// database query construction, and business logic should be
/// implemented through dedicated abstractions where appropriate.
///
/// FUTURE CONSIDERATIONS
///
/// - Request tracing and observability
/// - Cancellation token propagation
/// - Consistent API error handling
/// - Reusable pagination and sorting conventions
///
/// These are architectural considerations, not commitments
/// to implement every capability in this base class.
/// </remarks>
[ApiController]
public abstract class ApiControllerBase : ControllerBase
{
    /// <summary>
    /// Retrieves the remote IP address associated with the current HTTP connection.
    /// </summary>
    /// <returns>
    /// The remote IP address, or null if unavailable. 
    /// </returns>
    protected IPAddress? GetRemoteIpAddress()
    {
        return HttpContext.Connection.RemoteIpAddress;
    }

    /// <summary>
    /// Retrieves the User-Agent header from the current HTTP request.
    /// </summary>
    /// <returns>
    /// The User-Agent value, or null if missing or empty.
    /// </returns>
    protected string? GetUserAgent()
    {
        var userAgent = Request.Headers.UserAgent.ToString();

        return string.IsNullOrWhiteSpace(userAgent) ? null : userAgent;
    }
}
