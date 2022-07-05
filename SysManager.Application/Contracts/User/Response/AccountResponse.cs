namespace SysManager.Application.Contracts.Users.Request
{
     public class AccountResponse
    {
        public AccountResponse()
        {
        }
        public string Id { get; set; }
        public string Message { get; set; }
        public string Token { get; set; }
    }
}