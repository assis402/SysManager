namespace SysManager.Application.Contracts.ProductType.Request
{
    public class ProductTypeGetByFilterRequest
    {
        public string Name { get; set; }
        public bool? Active { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}