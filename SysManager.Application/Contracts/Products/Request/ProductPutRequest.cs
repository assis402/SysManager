using System;

namespace SysManager.Application.Contracts.Users.Request
{
    public class ProductPutRequest
    {
        public Guid Id { get; set; }
        public string ProductCode { get; set; }
        public string Name { get; set; }
        public string ProductType { get; set; }
        public string ProductCategory { get; set; }
        public string ProductUnity { get; set; }
        public string CostPrice { get; set; }
        public string Percentage { get; set; }
        public string Price { get; set; }
        public bool Active { get; set; }
    }
}