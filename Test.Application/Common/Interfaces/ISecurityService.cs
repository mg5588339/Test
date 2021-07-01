using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Application.Common.Interfaces
{
    public interface ISecurityService
    {
        string HashPassword(string password);
        bool VerifyHashedPassword(string hashedPassword, string password);
    }
}
