using System;

namespace Domain.App.Common
{
    public partial class AttachmentContent
    {
        public Guid Id { get; set; }
        public byte[] FileContent { get; set; }

        public Attachment Attachment { get; set; }
    }
}
