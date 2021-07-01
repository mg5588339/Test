using System;
using Test.Domain.Common;

namespace Test.Domain.Entities.Users
{
    public class User : BaseEntity<Guid>
    {
        #region properties

        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }

        #endregion
    }
}