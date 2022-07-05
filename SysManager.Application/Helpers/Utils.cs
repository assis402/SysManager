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
            return new ResultData<T>(data)
            {
                Success = true
            };
        }

        public static ResultData<T> ErrorData<T>(T data)
        {
            return new ResultData<T>(data)
            {
                Success = false
            };
        }

        public static IActionResult Convert(this ResultData resultData) 
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

        public static string Description(this Enum valorEnum) => valorEnum.GetAttribute<DescriptionAttribute>().Description;

        public static List<string> ToErrorCodeList(this IList<ValidationFailure> list)
        {
            var result = new List<string>();

            foreach (var item in list)
                result.Add(item.ErrorMessage);

            return result;
        }

        public static string GetDateExpired(int value) => DateTime.Now.AddMinutes(value).ToString("yyyyMMddHHmmss");

        public static string ToBase64Encode(this string data) => System.Convert.ToBase64String(Encoding.UTF8.GetBytes(data));
    }
}