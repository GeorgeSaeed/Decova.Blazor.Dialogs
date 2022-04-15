using Decova.Blazor;
using Decova.Blazor.Dialogs;
using Example2;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddCircuitsFrom(typeof(U_DialogContainerCircuit).Assembly, 
                                 typeof(T_Dialog).Assembly,
                                 typeof(U_TabGroupsInstaller).Assembly);
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

var host = builder.Build();

host.Services.InstantiateUniCircuits();
await host.RunAsync();
