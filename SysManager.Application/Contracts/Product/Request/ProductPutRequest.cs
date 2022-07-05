using System;

namespace SysManager.Application.Contracts.Product.Request
{
    public class ProductPutRequest
    {
        public Guid Id { get; set; }
        public string ProductCode { get; set; }
        public string Name { get; set; }
        public decimal CostPrice { get; set; }
        public decimal Percentage { get; set; }
        public decimal Price { get; set; }
        public bool Active { get; set; }
    }
}