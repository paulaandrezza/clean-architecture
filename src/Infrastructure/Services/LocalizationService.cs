using Application.Common.Interfaces;
using Infrastructure.Localization;
using System.Globalization;
using System.Resources;

namespace Infrastructure.Services
{
    public class LocalizationService : ILocalization
    {
        private readonly ResourceManager _resourceManager;

        public LocalizationService()
        {
            _resourceManager = new ResourceManager(typeof(Catalog));
        }
        public string GetString(string key, CultureInfo cultureInfo)
        {
            return _resourceManager.GetString(key, cultureInfo) ?? key;
        }
    }
}
