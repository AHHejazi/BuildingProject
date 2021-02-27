﻿using Domain.App.Common;
using Domain.App.Entities.Lookup;
using System.Collections.Generic;

namespace Domain.App.Entities
{
    public class Project : AuditableEntity
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
        public bool? IsActive { get; set; }
        public string SerialNumber { get; set; }

        // To check if we need to add 
        public ICollection<Building> Buildings { get; set; }
        public ICollection<ProjectType> ProjectTypes { get; set; }
        //// Added Attributes
        public int ProjectTypeId { get; set; }
        public int TotalArea { get; set; }
        public int InstrumentNumber { get; set; }
        public int BuildingLicenseNumber { get; set; }
        public int FloorsNumber { get; set; }
        public string BuildingTechnique { get; set; }
        public int EstimatedCost { get; set; }
        public string InstrumentAttachment { get; set; }
        public string BuildingLicenseAttachment { get; set; }
        public string ConstructionDiagrams { get; set; }
        public string MechanicalDiagrams { get; set; }
        public string ArchitecturalDiagrams { get; set; }
        public string ElictricalDiagrams { get; set; }
        public string SoilReport { get; set; }
        public string SurveyReport { get; set; }
        

    }
}

