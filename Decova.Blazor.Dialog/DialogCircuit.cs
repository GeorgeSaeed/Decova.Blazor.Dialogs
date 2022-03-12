using Decova.Circuits;

namespace Decova.Blazor.Dialogs;

public class DialogCircuit : Circuit
{
    public DialogCircuit()
    {
        Console.WriteLine("???????????????? DialogCircuit constructed");
    }

    [CircuitNode]
    public bool IsOpen { get; set; } = false;

    [CircuitNode(nameof(IsOpen))]
    public string LayoutCss { get; private set; } = "layout";
    string ___LayoutCss()
    {
        switch (IsOpen)
        {
            case false:
                return "layout closed";
            case true:
                return "layout open";
        }
    }

    [CircuitNode(nameof(IsOpen))]
    public string CurtainCss { get; private set; } = "curtain";
    string ___CurtainCss()
    {
        switch (IsOpen)
        {
            case false:
                return "curtain animate-out";
            case true:
                return "curtain animate-in";
        }
    }

    [CircuitNode(nameof(IsOpen))]
    public string DialogBodyCss { get; private set; } = "box";
    private string ___DialogBodyCss()
    {
        switch(this.IsOpen)
        {
            case false:
                return "box animate-out";
            case true:
                return "box animate-in";
        }
    }

    public virtual void OnDismiss(out bool cancelDismissing)
    {
        cancelDismissing = false;
    }

    protected override void OnLocalStormResolved(IEnumerable<NodeChange> changedProperties)
    {
        Console.WriteLine("#########################################");
        Console.WriteLine(this.LayoutCss);
        Console.WriteLine(this.CurtainCss);
        Console.WriteLine(this.DialogBodyCss);
        Console.WriteLine("#########################################");
        base.OnLocalStormResolved(changedProperties);
    }
}
