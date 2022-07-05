using System;

namespace SysManager.Application.Contracts.Category.Request
{
    public class CategoryPostRequest
    {
        public string Name { get; set; }
        public string ParentId { get; set; }
        public bool Active { get; set; }
    }
}