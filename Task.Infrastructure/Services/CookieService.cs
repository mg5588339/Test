using Microsoft.AspNetCore.Http;
using System;
using Test.Application.Common.Interfaces;

namespace Test.Infrastructure.Services
{
    public class CookieService: ICookieService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CookieService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string Get(string key)
        {
            return _httpContextAccessor.HttpContext.Request.Cookies.TryGetValue(key, out string value) ? value : null;
        }
        
        public void Set(string key, string value, int? expireTime)
        {
            CookieOptions option = new CookieOptions();
            option.SameSite = SameSiteMode.Strict;
            option.Secure = true;
            //option.Domain = _httpContextAccessor.HttpContext.Request.Host.Value;
            //option.Path = "/ck/http";

            if (expireTime.HasValue)
                option.Expires = DateTime.Now.AddMinutes(expireTime.Value);
            else
                option.Expires = DateTime.Now.AddMilliseconds(10);

            _httpContextAccessor.HttpContext.Response.Cookies.Append(key, value, option);
        }

        public void Remove(string key)
        {
            _httpContextAccessor.HttpContext.Response.Cookies.Delete(key);
        }
    }
}
