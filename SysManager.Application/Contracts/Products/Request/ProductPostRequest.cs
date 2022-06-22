using System;

namespace SysManager.Application.Contracts.Users.Request
{
	public class UserPostRequest
	{
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}