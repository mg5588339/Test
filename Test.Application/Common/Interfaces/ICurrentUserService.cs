using System;

namespace Test.Application.Common.Interfaces
{
    public interface ICurrentUserService
    {
        Guid UserId { get; }
        string UserIp { get; }
        string Mobile { get; }
        string UrlReferer { get; set; }
    }
}
