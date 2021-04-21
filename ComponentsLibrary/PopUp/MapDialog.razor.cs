using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace ComponentsLibrary.PopUp
{
    public partial class MapDialog
    {
        [Inject]
        IJSRuntime JSRuntime { get; set; }
        public bool ShowDialog { get; set; }

        private string location;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (ShowDialog)
            {
                location =  await JSRuntime.InvokeAsync<string>("buildingApp.initialize", null);
            }
        }

        [Parameter]
        public EventCallback<string> CloseEventCallback { get; set; }

        public void Show()
        {
            ShowDialog = true;
            StateHasChanged();
        }

        public async Task Close()
        {
            ShowDialog = false;
            if (!string.IsNullOrEmpty(location))
            {

                await CloseEventCallback.InvokeAsync(location);
            }
            StateHasChanged();
        }
       
    }
}
