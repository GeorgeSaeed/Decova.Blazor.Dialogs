using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using Newtonsoft.Json.Linq;

namespace Decova.Blazor.Dialogs;

public partial class Dialog
{



    //[Inject]
    //public IJSRuntime Js { get; set; }





    protected override void OnInitialized()
    {
        base.OnInitialized();
        this.Circuit.OnChangedInGlobalStorm(StateHasChanged);
    }
}

