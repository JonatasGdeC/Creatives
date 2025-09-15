using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Creatives;
using MudBlazor.Services;

WebAssemblyHostBuilder builder = WebAssemblyHostBuilder.CreateDefault(args: args);
builder.RootComponents.Add<App>(selector: "#app");
builder.RootComponents.Add<HeadOutlet>(selector: "head::after");

builder.Services.AddMudServices();

builder.Services.AddScoped(implementationFactory: sp => new HttpClient { BaseAddress = new Uri(uriString: builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
