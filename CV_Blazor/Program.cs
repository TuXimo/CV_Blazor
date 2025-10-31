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
            
            // La cultura ya fue establecida por el script de pre-boot en index.html 
            // y cargada por el Blazor runtime. Solo la recuperamos.
            var culture = CultureInfo.CurrentUICulture;

            // Aplicamos la cultura al hilo de la aplicación y el UI para consistencia.
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
                // Ignorar errores, por ejemplo, si se está ejecutando en un contexto limitado como un bot.
            }

            await host.RunAsync();
        }
    }
}