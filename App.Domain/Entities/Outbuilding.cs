using Domain.App.Common;
using Domain.App.Entities.Lookup;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.App.Entities
{
    public class Outbuilding : AuditableEntity
    {
        public Guid Id { get; set; }

        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string Number { get; set; }
    }
}
