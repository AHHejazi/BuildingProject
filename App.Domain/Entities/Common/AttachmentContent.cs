using System;

namespace App.Domain.Common
{
    public partial class AttachmentConten
    {
        public Guid Id { get; set; }
        public byte[] FileContent { get; set; }

        public Attachment Attachment { get; set; }
    }
}
