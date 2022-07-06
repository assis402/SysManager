namespace SysManager.Application.Contracts.Product.Request
{
    public class ProductGetByFilterRequest
    {
        public string Name { get; set; }
        public bool? Active { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}