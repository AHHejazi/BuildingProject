using System;
using System.Collections.Generic;
using System.Text;

namespace Application.App.Contracts.Identity
{
    public class TokenProvider
    {
        public string XsrfToken { get; set; }

    }

    public class InitialApplicationState { 
        public string XsrfToken { get; set; }

    }

}
