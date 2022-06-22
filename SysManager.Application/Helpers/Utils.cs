using Microsoft.AspNetCore.Mvc;

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

        public static IActionResult Convert(ResultData resultData) 
        {
            if (resultData.Success)
                return new OkObjectResult(resultData);

            else return new BadRequestObjectResult(resultData);
        }
    }
}