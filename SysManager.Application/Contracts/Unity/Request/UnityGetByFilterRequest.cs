namespace SysManager.Application.Contracts.Unity.Request
{
    public class UnityGetByFilterRequest
    {
        public string Name { get; set; }
        public bool? Active { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}