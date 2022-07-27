using System;
using System.Collections.Generic;
using System.Text;

namespace SysManager.Application.Helpers
{
    public class ErrorResponse
    {
        public ErrorResponse(string error)
        {
            Errors = new List<string>
            {
                error
            };
        }

        public ErrorResponse(List<string> errorList)
        {
            Errors = new List<string>();
            Errors = errorList;
        }

        public ErrorResponse() => Errors = new List<string>();

        public List<string> Errors { get; set; }
    }
}
