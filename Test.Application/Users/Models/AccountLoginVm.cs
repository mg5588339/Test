namespace Test.Application.Users.Models
{
    public class AccountLoginVm
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ReMemberMe { get; set; }
    }

    public enum LogInUserStatus
    {
        IsNotFoundUser,
        IsNotActiveUser,
        Success,
        Error
    }
}
