using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.App.Services.Lookups
{
    public interface ILookupServices
    {
       public  List<SelectListItem> GetProjectTypeList();
    }
}
