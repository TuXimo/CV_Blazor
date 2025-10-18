using Microsoft.AspNetCore.Components;

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
            builder.Services.AddScoped<LocalizationService>();

            builder.Services.AddLocalization();

            var host = builder.Build();

            const string defaultCulture = "en-US";

            // 1. Obtener servicios necesarios
            var js = host.Services.GetRequiredService<IJSRuntime>();
            var navManager = host.Services.GetRequiredService<NavigationManager>();

            // 2. Extraer el parámetro 'lang' de la URL
            var uri = new Uri(navManager.Uri);
            var langQuery = System.Web.HttpUtility.ParseQueryString(uri.Query).Get("lang");

            string cultureCode;
            if (!string.IsNullOrEmpty(langQuery) && (langQuery == "en-US" || langQuery == "es-ES"))
            {
                // Si el parámetro 'lang' es válido, usarlo y guardarlo
                cultureCode = langQuery;
                await js.InvokeVoidAsync("blazorCulture.set", cultureCode);
            }
            else
            {
                // Si no hay parámetro, usar el valor de localStorage o el predeterminado
                cultureCode = await js.InvokeAsync<string>("blazorCulture.get");
                if (string.IsNullOrEmpty(cultureCode))
                {
                    // Si no hay nada en localStorage, intentar detectar el idioma del navegador
                    var browserLanguage = await js.InvokeAsync<string>("blazorCulture.getBrowserLanguage");
                    // Si el idioma del navegador es español, usar es-ES. Para todo lo demás, usar en-US.
                    cultureCode = browserLanguage != null && browserLanguage.StartsWith("es") 
                        ? "es-ES" 
                        : defaultCulture;
                }
            }

            var culture = new CultureInfo(cultureCode);

            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;

            var localizationService = host.Services.GetRequiredService<LocalizationService>();
            localizationService.InitializeCulture(culture);

            await host.RunAsync();
        }
    }
}

//dotnet publish -c Release -r browser-wasm --self-contained