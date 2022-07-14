namespace SysManager.Application.Contracts.Unity.Request
{
    public class UnityGetByFilterRequest
    {
        public string Name { get; set; }
        public string Active { get; set; }
        public int page { get; set; }
        public int pageSize { get; set; }
    }
}