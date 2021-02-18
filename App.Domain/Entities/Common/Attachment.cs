// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Attachment.cs" company="Usama Nada">
//   No Copyright .. Copy, Share, and Evolve.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace App.Domain.Common
{

    public partial class Attachment : AuditableEntity
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public string Extension { get; set; }
        public string FilePath { get; set; }
        public string ContentType { get; set; }
        public string TitleAr { get; set; }
        public string TitleEn { get; set; }
        public string DescriptionAr { get; set; }
        public string DescriptionEn { get; set; }
        public int AttachmentTypeId { get; set; }
        public byte[] Thumbnail { get; set; }

        public AttachmentType AttachmentType { get; set; }
        public AttachmentContent AttachmentContent { get; set; }

    }

}


