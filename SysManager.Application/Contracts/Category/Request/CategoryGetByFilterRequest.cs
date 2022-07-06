namespace SysManager.Application.Contracts.Category.Request
{
    public class CategoryGetByFilterRequest
    {
        public string Name { get; set; }
        public bool? Active { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}