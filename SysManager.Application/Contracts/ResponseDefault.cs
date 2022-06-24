using System;

namespace SysManager.Application.Contracts
{
	public class ResponseDefault
	{
        public ResponseDefault(string id, string message, bool hasError)
        {
            Id = id;
            Message = message;
            HasError = hasError;
        }

        public string Id { get; set; }
        public string Message { get; set; }
        public bool HasError { get; set; }
    }
}

