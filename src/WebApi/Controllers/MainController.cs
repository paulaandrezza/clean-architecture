using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace WebApi.Controllers
{
    public abstract class MainController : ControllerBase
    {
        protected CultureInfo Culture
        {
            get
            {
                var locale = User?.FindFirst("Locale")?.Value;
                return !string.IsNullOrEmpty(locale) ? new CultureInfo(locale) : new CultureInfo("pt-BR");
            }
        }

        protected bool UserLogged => User?.Identity?.IsAuthenticated ?? false;
    }
}
