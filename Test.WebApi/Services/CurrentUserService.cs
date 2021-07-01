using Microsoft.AspNetCore.Http;
using System;
using System.Security.Claims;
using Test.Application.Common.Interfaces;

namespace Test.WebUI.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            if (httpContextAccessor?.HttpContext?.User != null && httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                UserId = Guid.Parse(httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
                Mobile = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.MobilePhone);
            }
            UserIp = httpContextAccessor?.HttpContext?.Connection.RemoteIpAddress.ToString();
            UrlReferer = httpContextAccessor?.HttpContext?.Request.Headers["Referer"].ToString();
        }

        public Guid UserId { get; }
        public string UserIp { get; }
        public string Mobile { get; }
        public string UrlReferer { get; set; }
    }
}
