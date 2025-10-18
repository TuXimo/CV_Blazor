using System.Globalization;

namespace CV_Blazor.Services
{
    public class LocalizationService
    {
        public event Action? OnChange;

        public CultureInfo CurrentCulture { get; private set; } = CultureInfo.CurrentUICulture;

        public LocalizationService() { }

        public void SetCulture(string cultureCode)
        {
            var culture = new CultureInfo(cultureCode);
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
            CurrentCulture = culture;

            OnChange?.Invoke();
        }

        internal void InitializeCulture(CultureInfo culture)
        {
            CurrentCulture = culture;
            // No es necesario invocar OnChange aquí, ya que es la carga inicial.
        }
    }
}
