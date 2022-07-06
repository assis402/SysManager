using System;

namespace SysManager.Application.Contracts.ProductType.Request
{
    public class ProductTypePostRequest
    {
        public string Name { get; set; }
        public bool Active { get; set; }
    }
}