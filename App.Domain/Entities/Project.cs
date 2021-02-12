using App.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Entities
{
    public class Project: AuditableEntity
    {
     
            public System.Guid Id { get; set; }
            public string NameAr { get; set; }
            public string NameEn { get; set; }
            public string Number { get; set; }
            public string ContractorName { get; set; }
            public string ConsultingOfficeName { get; set; }
            public string CityName { get; set; }
            public string QuarterName { get; set; }
            public string PropertyFullAddress { get; set; }
            public string PropertyNumber { get; set; }
            public string PropertyLatitude { get; set; }
            public string PropertyLongitude { get; set; }
            public bool IsActive { get; set; }
            public string SerialNumber { get; set; }
            
        }
    }

