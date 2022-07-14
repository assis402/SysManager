namespace SysManager.Application.Contracts.Product.Request
{
    public class ProductPostRequest
    {
        public string ProductCode { get; set; }
        public string Name { get; set; }
        public string ProductTypeId { get; set; }
        public string ProductCategoryId { get; set; }
        public string ProductUnityId { get; set; }
        public decimal CostPrice { get; set; }
        public decimal Percentage { get; set; }
        public decimal Price { get; set; }
        public bool Active { get; set; }
    }
}