using Domain.App.Common;

namespace Application.App.Services.Supplies
{
   public class SuppliesDto :  AuditableEntity 
    {
        public System.Guid Id { get; set; }

        public string NameAr { get; set; }

        public string NameEn { get; set; }
        
    }
}
