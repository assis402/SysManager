﻿using System;

namespace SysManager.Application.Contracts.Category.Request
{
    public class CategoryPutRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
    }
}