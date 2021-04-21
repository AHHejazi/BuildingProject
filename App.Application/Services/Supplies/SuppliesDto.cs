using Domain.App.Common;
using Framework.Core.ListManagment;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.App.Services.Supplies
{
   public class SuppliesDto :  AuditableEntity 
    {
        public System.Guid Id { get; set; }

        public string NameAr { get; set; }

        public string NameEn { get; set; }
        
    }
}
