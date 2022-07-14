namespace SysManager.Application.Contracts.Users.Request
{
    public class UserPostLoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}