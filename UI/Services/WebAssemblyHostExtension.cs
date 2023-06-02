using System.Globalization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;

namespace UI.Services
{
    public static class WebAssemblyHostExtension
    {
        public static async Task SetDefaultCulture(this WebAssemblyHost host)
        {
            CultureInfo culture;
            IJSRuntime jsInterop = host.Services.GetRequiredService<IJSRuntime>();
            try
            {
                var result = await jsInterop.InvokeAsync<string>("blazorCulture.get");
                culture = new CultureInfo(string.IsNullOrEmpty(result) ? "en" : result);
            }
            catch (Exception e)
            {
                culture = new CultureInfo("uk");
            }
            
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
            await jsInterop.InvokeAsync<string>("blazorCulture.set", "uk");
        }
    }
}