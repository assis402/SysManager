using SysManager.Application.Contracts;

namespace SysManager.Application.Helpers
{
    public static class Utils
    {
        public static ResultData<T> SuccessData<T>(T data, bool success)
        {
            var result = new ResultData<T>(data);
            result.Success = success;
            return result;
        }
    }
}