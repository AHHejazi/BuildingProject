﻿using System;

namespace Framework.Core.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string name, object key)
            : base($"{name} ({key}) is not found")
        {
        }
    }
}
