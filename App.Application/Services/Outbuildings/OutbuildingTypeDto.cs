using Domain.App.Common;
using System;

namespace Application.App.Services.Outbuildings
{
   public class OutbuildingTypeDto :  AuditableEntity 
    {
        public Guid Id { get; set; }

        public string NameAr { get; set; }

        public string NameEn { get; set; }
    }
}
