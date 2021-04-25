using Application.App.Enum;
using Domain.App.Common;
using Domain.App.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Application.App.Services.Projects
{
    public class ProjectDiagramsDto
    {
        public System.Guid Id { get; set; }
        public Guid? InstrumentAttachmentId { get; set; }
        public Guid? BuildingLicenseAttachmentId { get; set; }
        public Guid? ConstructionDiagramId { get; set; }
        public Guid? MechanicalDiagramId { get; set; }
        public Guid? ArchitecturalDiagramId { get; set; }
        public Guid? ElictricalDiagramId { get; set; }
        public Guid? SoilReportId { get; set; }
        public Guid? SurveyReportId { get; set; }


        public List<FileData> fileData { get; set; }

        public Guid AttachemntId { get; set; }

        public IReadOnlyList<Attachment> Attachments { get; set; }
    }


  

    public class FileData
    {
        public byte[] Data { get; set; }
        public string FileType { get; set; }
        public long Size { get; set; }
        public int AttachemntType { get; set; }
        public string FileName { get; set; }
    }
}
