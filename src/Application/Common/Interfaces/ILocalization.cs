using System.Globalization;

namespace Application.Common.Interfaces
{
    public interface ILocalization
    {
        public string GetString(string key, CultureInfo cultureInfo);
    }
}
