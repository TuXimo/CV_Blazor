using System.Globalization;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace CV_Blazor.Services
{
    public class LocalizationService
    {
        private readonly IJSRuntime _jsRuntime;
        private readonly NavigationManager _navManager;

        public CultureInfo CurrentCulture { get; private set; } = CultureInfo.CurrentUICulture;

        public LocalizationService(IJSRuntime jsRuntime, NavigationManager navManager)
        {
            _jsRuntime = jsRuntime;
            _navManager = navManager;
        }

        public async Task SetCultureAsync(string cultureCode)
        {
            await _jsRuntime.InvokeVoidAsync("blazorCulture.set", cultureCode);
            // Forzar una recarga de la página para aplicar la nueva cultura en toda la aplicación.
            // El 'true' fuerza una recarga desde el servidor, limpiando el estado de WASM.
            _navManager.NavigateTo(_navManager.Uri, forceLoad: true);
        }

        internal void InitializeCulture(CultureInfo culture)
        {
            CurrentCulture = culture;
        }
    }
}
