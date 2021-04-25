using Domain.App.Common;
using Domain.App.Entities.Lookup;
using System;
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
        public ICollection<ProjectType> ProjectType { get; set; }
        //// Added Attributes
        public int ProjectTypeId { get; set; }
        public int TotalArea { get; set; }
        public int InstrumentNumber { get; set; }
        public int BuildingLicenseNumber { get; set; }
        public int FloorsNumber { get; set; }
        public string BuildingTechnique { get; set; }
        public int EstimatedCost { get; set; }
        public Guid? InstrumentAttachmentId { get; set; }
        public Guid? BuildingLicenseAttachmentId { get; set; }
        public Guid? ConstructionDiagramsId { get; set; }
        public Guid? MechanicalDiagramsId { get; set; }
        public Guid? ArchitecturalDiagramsId { get; set; }
        public Guid? ElictricalDiagramsId { get; set; }
        public Guid? SoilReportId { get; set; }
        public Guid? SurveyReportId { get; set; }
    }
}

