using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;

namespace Decova.Blazor.Dialogs;

public partial class Dialog
{
    public Dialog()
    {
        
    }

    [Parameter]
    public DialogCircuit PRM_Circuit { get; set; }

    [Parameter]
    public Func<bool> PRM_ShouldDismiss { get; set; }

    [Inject]
    public IJSRuntime Js { get; set; }

    [Parameter]
    public RenderFragment SLOT_Body { get; set; }

    void OnCurtainClick(MouseEventArgs e)
    {
        if (this.PRM_ShouldDismiss == null || this.PRM_ShouldDismiss())
        {
            this.PRM_Circuit.IsOpen = false;
        }
    }

    protected override void OnInitialized()
    {
        base.OnInitialized();
        if(this.PRM_Circuit != null)
        {
            this.PRM_Circuit.OnChangedInGlobalStorm(StateHasChanged);
        }
    }
}

