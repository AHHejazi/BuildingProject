using App.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Entities
{
    public class Incomes : AuditableEntity
    {
        public Guid Id { get; set; }

        public Building Building { get; set; }

        public Building BuildingId { get; set; }

        public decimal Amount { get; set; }

        //To Discussing later
        public Guid ShareHolderId { get; set; }

        public DateTime IncomeDate { get; set; }

        public string Description { get; set; }

    }
}
