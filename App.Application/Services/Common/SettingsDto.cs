using System;
using System.Collections.Generic;
using System.Text;

namespace Application.App.Services.Common
{
    public class SettingsDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ValueType { get; set; }

        public string Value { get; set; }

        public string GroupName { get; set; }

    }
}
