namespace SysManager.Application.Contracts
{
    public class ResponseDefault
    {
        public ResponseDefault(string message, bool hasError, string id = null)
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