using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace OfficeOS.Api.Controllers.Base
{
    [ApiController]
    public abstract class ApiControllerBase : ControllerBase
    {
        protected IPAddress? GetRemoteIpAddress()
        {
            return HttpContext.Connection.RemoteIpAddress;
        }
        
        protected string? GetUserAgent()
        {
            var userAgent = Request.Headers.UserAgent.ToString();

            return string.IsNullOrWhiteSpace(userAgent) ? null : userAgent;
        }
    }
}
