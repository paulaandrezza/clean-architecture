using Application.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace WebApi.Controllers
{
    public abstract class MainController : ControllerBase
    {
        protected MainController(IApplicationUserService appUser)
        {
            if (!appUser.IsAuthenticated) return;

            UserId = int.TryParse(appUser.UserId, out var userId) ? userId : 0; ;
            Culture = !string.IsNullOrEmpty(appUser.Locale) ? new CultureInfo(appUser.Locale) : new CultureInfo("pt-BR");
            UserLogged = true;
        }

        protected int UserId { get; set; }
        protected CultureInfo Culture { get; set; }
        protected bool UserLogged { get; set; }
    }
}
