using System;

namespace SysManager.Application.Contracts
{
	public class ResultData
	{
        public bool Success { get; set; }

        public ResultData(bool success)
        {
            Success = success;
        }
    }

    public class ResultData<T> : ResultData
    {
        public T Data { get; set; }

        public ResultData(T data) : base(true)
        {
            Data = data;
        }
    }
}

