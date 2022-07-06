namespace SysManager.Application.Contracts.Unity.Request
{
    public class UnityPostRequest
    {
        public string Name { get; set; }
        public bool Active { get; set; } = true;
    }
}