using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;
using System.Globalization;
using CV_Blazor.Services;

namespace CV_Blazor
{
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
            string cultureCode = defaultCulture;

            try
            {
                var js = host.Services.GetRequiredService<IJSRuntime>();
                var navManager = host.Services.GetRequiredService<NavigationManager>();

                // Intentar obtener parámetro "lang" de la URL
                try
                {
                    var uri = new Uri(navManager.Uri);
                    var langQuery = System.Web.HttpUtility.ParseQueryString(uri.Query).Get("lang");
                    if (!string.IsNullOrEmpty(langQuery) && (langQuery == "en-US" || langQuery == "es-ES"))
                    {
                        cultureCode = langQuery;
                        await js.InvokeVoidAsync("blazorCulture.set", cultureCode);
                    }
                    else
                    {
                        // Intentar leer de localStorage
                        var storedCulture = await js.InvokeAsync<string>("blazorCulture.get");
                        if (!string.IsNullOrEmpty(storedCulture))
                        {
                            cultureCode = storedCulture;
                        }
                        else
                        {
                            // Detectar idioma del navegador
                            var browserLang = await js.InvokeAsync<string>("blazorCulture.getBrowserLanguage");
                            cultureCode = browserLang != null && browserLang.StartsWith("es") ? "es-ES" : defaultCulture;
                        }
                    }
                }
                catch
                {
                    // Si falla todo lo anterior, usar valor por defecto
                    cultureCode = defaultCulture;
                }

            }
            catch
            {
                cultureCode = defaultCulture;
            }

            // Aplicar cultura
            var culture = new CultureInfo(cultureCode);
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;

            // Inicializar servicio de localización
            try
            {
                var localizationService = host.Services.GetRequiredService<LocalizationService>();
                localizationService.InitializeCulture(culture);
            }
            catch
            {
                // Ignorar errores en bots
            }

            await host.RunAsync();
        }
    }
}

//dotnet publish -c Release -r browser-wasm --self-contained