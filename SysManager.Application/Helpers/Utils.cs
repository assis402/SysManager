using Microsoft.AspNetCore.Mvc;

namespace SysManager.Application.Helpers
{
    public static class Utils
    {
        public static ResultData<T> SuccessData<T>(T data)
        {
            var result = new ResultData<T>(data);
            result.Success = true;
            return result;
        }

        public static ResultData<T> ErrorData<T>(T data)
        {
            var result = new ResultData<T>(data);
            result.Success = false;
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