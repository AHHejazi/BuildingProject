using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.App.Contracts.Persistence
{
   public interface ILookupRepository
    {
        public List<SelectListItem> GetProjectTypeList();
    }
}
