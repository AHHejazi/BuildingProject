// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AttachmentType.cs" company="Usama Nada">
//   No Copyright .. Copy, Share, and Evolve.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace Domain.App.Common
{

    public class AttachmentType : AuditableEntity
    {
        public AttachmentType()
        {
            Attachments = new HashSet<Attachment>();
        }

        public int Id { get; set; }
        public string NameAr { get; set; } 

        public string NameEn { get; set; }
        public string Code { get; set; }

        public string AllowedFilesExtension { get; set; }

        public int? ImageMaxHeight { get; set; }

        public int? ImageMaxWidth { get; set; }

        public bool IsImage { get; set; }

        public bool IsMandatory { get; set; }

        public int MaxSizeInMegabytes { get; set; }

        public ICollection<Attachment> Attachments { get; set; }
    }


    public enum AttachmentTypes
    {
        GeneralFileAttachment = 1,

        GeneralImageAttachment = 2
    }

}