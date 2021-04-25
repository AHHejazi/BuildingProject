using Application.App.Enum;
using Domain.App.Common;
using Domain.App.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Application.App.Services.Projects
{
    public class ProjectDto
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
        //// Added Attributes
        public int TotalArea { get; set; }
        public int InstrumentNumber { get; set; }
        public int BuildingLicenseNumber { get; set; }
        public int FloorsNumber { get; set; }
        public string BuildingTechnique { get; set; }
        public int EstimatedCost { get; set; }
        public int StocksNumber { get; set; }
        public int Cost { get; set; }
        public int ProjectTypeId { get; set; }


        public Guid? InstrumentAttachmentId { get; set; }
        public Guid? BuildingLicenseAttachmentId { get; set; }
        public Guid? ConstructionDiagramId { get; set; }
        public Guid? MechanicalDiagramId { get; set; }
        public Guid? ArchitecturalDiagramId { get; set; }
        public Guid? ElictricalDiagramId { get; set; }
        public Guid? SoilReportId { get; set; }
        public Guid? SurveyReportId { get; set; }

    }

   
}
