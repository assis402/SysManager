using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using FluentValidation.Results;
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

        public static T GetAttribute<T>(this Enum valorEnum) where T : System.Attribute
        {
            var type = valorEnum.GetType();
            var memInfo = type.GetMember(valorEnum.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(T), false);
            return (attributes.Length > 0) ? (T)attributes[0] : null;
        }
        
        public static string Description(this Enum valorEnum)
        {
            return valorEnum.GetAttribute<DescriptionAttribute>().Description;
        }

        public static List<string> ToErrorCodeList(this IList<ValidationFailure> list)
        {
            var _result = new List<string>();
            foreach (var item in list)
                _result.Add(item.ErrorMessage);
            return _result;
        }

        public static string GetDateExpired(int value)
        {
            var date = DateTime.Now.AddMinutes(value);
            return date.ToString("yyyyMMddHHmmss");
        }

        public static string ToBase64Encode(this string data)
        {
            return System.Convert.ToBase64String(Encoding.UTF8.GetBytes(data));
        }
    }
}