using Microsoft.AspNetCore.Components;
using System;

namespace ComponentsLibrary.Shared.Common
{
    public partial class Pager : ComponentBase
    {
        [Parameter]
        public dynamic Result { get; set; }

        [Parameter]
        public Action<int> PageChanged { get; set; }

        protected int StartIndex { get; private set; } = 0;
        protected int FinishIndex { get; private set; } = 0;

        protected override void OnParametersSet()
        {
            StartIndex = Math.Max(Result.PageNumber - 5, 1);
            FinishIndex = Math.Min(Result.PageNumber + 5, Result.PageCount);

            base.OnParametersSet();
        }


        protected void PagerButtonClicked(int page)
        {
            PageChanged?.Invoke(page);
        }
    }
}
