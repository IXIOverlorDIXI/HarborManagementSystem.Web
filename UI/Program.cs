using System.Reflection;
using Blazored.LocalStorage;
using FluentValidation;
using IoC.Extensions;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using UI.Services;

namespace UI
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddMudServices();

            builder.Services.AddApplicationServices(builder.Configuration);
            
            builder.Services.AddBlazoredLocalStorage();

            builder.Services.AddLocalization();
            
            builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            
            builder.Services.AddSingleton<UserAuthorizationHelpService>();
            builder.Services.AddSingleton<LocalizationService>();
            
            var host = builder.Build();
            
            await host.SetDefaultCulture();

            await host.RunAsync();
        }
    }
}