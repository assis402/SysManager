namespace SysManager.Application.Helpers
{
    public class ResultData
    {
        public bool Success { get; set; }
        public object Data { get; set; }

        public ResultData(bool success, object data)
        {
            Success = success;
            Data = data;
        }
    }
}