using Decova.Circuits;
using Newtonsoft.Json.Linq;

namespace Decova.Blazor.Dialogs;

public class T_Dialog : TransientCircuit<T_Dialog>
{
    private static int _nextZIndex = 1000;

    public T_Dialog(U_TabGroupsInstaller u_TabGroupsInstaller)
    {
        Console.WriteLine("DialogCircuit constructor");
        this.U_TabGroupsInstaller = u_TabGroupsInstaller;

        this.U_TabGroupsInstaller.TabGroupSubmitted += U_TabGroupsInstaller_TabGroupSubmitted;

        this.LayoutCss = "layout";
        this.CurtainCss = "curtain";
        this.DialogBodyCss = "box";
    }

    private void U_TabGroupsInstaller_TabGroupSubmitted(object sender, U_TabGroupsInstaller.EventArgsTabGroupSubmitted e)
    {
        if(e.TabGroup == this._TabGroup)
        {
            this.OnSubmitted = DateTime.Now;
        }
    }


    [Node]
    public DateTime OnSubmitted
    { get => Get<DateTime>(nameof(OnSubmitted)); set => Set(nameof(OnSubmitted), value); }


    [Node]
    public bool IsOpen
    { get => Get<bool>(nameof(IsOpen)); set => Set(nameof(IsOpen), value); }


    [Node(nameof(IsOpen))]
    public string LayoutCss
    { get => Get<string>(nameof(LayoutCss)); set => Set(nameof(LayoutCss), value); }
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



    [Node(nameof(IsOpen))]
    public string CurtainCss
    { get => Get<string>(nameof(CurtainCss)); set => Set(nameof(CurtainCss), value); }
    string ___CurtainCss()
    {
        //Console.WriteLine("___CurtainCss");
        switch (IsOpen)
        {
            case false:
                return "curtain animate-out";
            case true:
                return "curtain animate-in";
        }
    }
    
    
    public U_TabGroupsInstaller U_TabGroupsInstaller { get; }

    public readonly string _TabGroup = Guid.NewGuid().ToString();

    [Node(nameof(IsOpen))]
    public string DialogBodyCss
    { get => Get<string>(nameof(DialogBodyCss)); set => Set(nameof(DialogBodyCss), value); }
    private string ___DialogBodyCss()
    {
        //Console.WriteLine("___DialogBodyCss");
        switch (this.IsOpen)
        {
            case false:
                return "box animate-out";
            case true:
                return "box animate-in";
        }
    }

    [Node]
    public bool IsBusy
    { get => Get<bool>(nameof(IsBusy)); set => Set(nameof(IsBusy), value); }


    [Node(nameof(IsOpen))]
    public int ZIndex
    { get => Get<int>(nameof(ZIndex)); set => Set(nameof(ZIndex), value); }
    int ___ZIndex()
    {
        if(this.IsOpen)
        {
            _nextZIndex++;
            return _nextZIndex;
        }
        else
        {
            return this.ZIndex;
        }
    }


    protected override void OnLocalStormResolved(IEnumerable<NodeChange> changedProperties)
    {
        base.OnLocalStormResolved(changedProperties);

        //Console.WriteLine("DialogBodyCss = " + DialogBodyCss);

        #region focus first input
        //####################################################################
        if (changedProperties.Any(p => p.NodeName == nameof(IsOpen)))
        {
            if (this.IsOpen)
            {
                Task.Delay(500).ContinueWith(t =>
                {
                    this.U_TabGroupsInstaller.FocusGroup(this._TabGroup);
                });
            }
        }
        //####################################################################
        #endregion
    }
}
