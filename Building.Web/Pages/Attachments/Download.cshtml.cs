using Application.App.Services.Common;
using Framework.Core.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace Building.Web.Pages.Attachments
{
    public class DownloadModel : PageModel
    {
        [BindProperty(SupportsGet =true)]
        public Guid Id { get; set; }

        private readonly IAttachmentService _attachmentService;
        public DownloadModel(IAttachmentService attachmentService)
        {
            _attachmentService = attachmentService;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            if (Id.IsNullOrDefault<Guid>())
            {
                return this.BadRequest();
            }

            var attach = await _attachmentService.GetAttachmentForDownloadAsync(Id);

            if (attach?.AttachmentContent != null)
            {
                return this.File(attach.AttachmentContent?.FileContent, attach.ContentType, attach.FileName);
            }

            return NotFound();
        }
    }
}