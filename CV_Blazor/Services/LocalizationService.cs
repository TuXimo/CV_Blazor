using System.Globalization;

namespace CV_Blazor.Services
{
    public class LocalizationService
    {
        public event Action? OnChange;

        public CultureInfo CurrentCulture { get; private set; }

        public LocalizationService()
        {
            CurrentCulture = CultureInfo.CurrentUICulture;
        }

        public void SetCulture(string cultureCode)
        {
            var culture = new CultureInfo(cultureCode);
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
            CurrentCulture = culture;

            OnChange?.Invoke();
        }
    }
}
