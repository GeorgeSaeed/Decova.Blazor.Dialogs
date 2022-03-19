using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using Newtonsoft.Json.Linq;

namespace Decova.Blazor.Dialogs;

public partial class Dialog : ComponentBase
{
    [Parameter]
    public DialogCircuit PRM_Circuit { get; set; }

    [Parameter]
    public Func<bool> PRM_ShouldDismiss { get; set; }

    //[Inject]
    //public IJSRuntime Js { get; set; }

    [Parameter]
    public RenderFragment SLOT_Body { get; set; }

    protected void OnCurtainClick(MouseEventArgs e)
    {
        if (this.PRM_ShouldDismiss == null || this.PRM_ShouldDismiss())
        {
            //js1.Run("alert('hi')");
            this.PRM_Circuit.IsOpen = false;
        }
    }

    protected override void OnInitialized()
    {
        base.OnInitialized();
        this.PRM_Circuit.OnChangedInGlobalStorm(StateHasChanged);
    }
}

