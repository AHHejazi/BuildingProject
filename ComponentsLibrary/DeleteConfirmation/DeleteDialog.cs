using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
namespace ComponentsLibrary.DeleteConfirmation
{
    public partial class DeleteDialog
    {

        public bool ShowDialog { get; set; }

        [Parameter]
        public string ItemId { get; set; }

        [Parameter]
        public EventCallback<bool> CloseEventCallback { get; set; }


        public void Show()
        {
            ShowDialog = true;
            StateHasChanged();
        }

        public void Close()
        {
            ShowDialog = false;
            StateHasChanged();
        }

        protected async Task HandleDelete()
        {
            ShowDialog = false;
            await CloseEventCallback.InvokeAsync(true);
            StateHasChanged();
        }
    }
}

