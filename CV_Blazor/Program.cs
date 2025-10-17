namespace CV_Blazor
{
    using Microsoft.AspNetCore.Components.Web;
    using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
    using Microsoft.JSInterop;
    using System.Globalization;
    using Services;

    public static class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped(_ => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddScoped<PortfolioService>();
            builder.Services.AddScoped<SkillService>();
            builder.Services.AddSingleton<LocalizationService>();

            builder.Services.AddLocalization();

            var host = builder.Build();

            const string defaultCulture = "en-US";

            var js = host.Services.GetRequiredService<IJSRuntime>();
            var result = await js.InvokeAsync<string>("blazorCulture.get");
            var culture = CultureInfo.GetCultureInfo(result ?? defaultCulture);

            if (result == null)
            {
                await js.InvokeVoidAsync("blazorCulture.set", defaultCulture);
            }

            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;

            var localizationService = host.Services.GetRequiredService<LocalizationService>();
            localizationService.InitializeCulture(culture);

            await host.RunAsync();
        }
    }
}

//dotnet publish -c Release -r browser-wasm --self-contained