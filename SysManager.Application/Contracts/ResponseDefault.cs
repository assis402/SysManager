using System;

namespace SysManager.Application.Contracts
{
	public class ResponseDefault
	{
        public Guid Id { get; set; }
        public string Message { get; set; }
        public bool HasError { get; set; }
    }
}

