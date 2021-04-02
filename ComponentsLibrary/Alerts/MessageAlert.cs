using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComponentsLibrary.Alerts
{
   public partial class MessageAlert
    {
        [Parameter]
        public string MessageText { get; set; }

        [Parameter]
        public string StatusClass { get; set; }
    }
}
