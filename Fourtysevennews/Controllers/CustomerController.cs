using Fourtysevennews.Entities.Auth;
using Fourtysevennews.Models.Auth;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using Uttambsolutionadmin.Apiservices.Auth;

namespace Fourtysevennews.Controllers
{
    [Authorize]
    [RequireHttps]
    public class CustomerController : BaseController
    {
        private readonly Uttambsolutioncustomerauthservices bl;
        public CustomerController(IConfiguration config)
        {
            bl = new Uttambsolutioncustomerauthservices(config);
        }
        #region User Signin
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Signinuser(string returnUrl = null)
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Signinuser(Userloginmodel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            var resp = await bl.Validatecustomer(model);
            if (resp.RespStatus == 0)
            {
                SetUserLoggedIn(resp, false);
                return RedirectToAction("Myprofile", "Home");
            }
            else if (resp.RespStatus == 401)
            {
                Warning(resp.RespMessage, true);
            }
            else
            {
                ModelState.AddModelError(string.Empty, resp.RespMessage);
            }
            return View();

        }
        #endregion

        #region Logout
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
        #endregion

        #region Other Methods

        private async void SetUserLoggedIn(Customermodelresponce user, bool rememberMe)
        {
            string userData = JsonConvert.SerializeObject(user);

            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Customermodel.CustomerId.ToString()),
                new Claim(ClaimTypes.Name, user.Customermodel.FullName),
                new Claim("FullNames", user.Customermodel.FullName),
                new Claim("Token", user.Token),
                new Claim("userData", userData),
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "ApplicationCookie");

            ClaimsPrincipal principal = new ClaimsPrincipal(new ClaimsIdentity[] { claimsIdentity });
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal,
            new AuthenticationProperties
            {
                IsPersistent = rememberMe,
                ExpiresUtc = new DateTimeOffset?(DateTime.UtcNow.AddMinutes(30))
            });
        }
        //private IActionResult RedirectToLocal(string returnUrl)
        //{
        //    if (Url.IsLocalUrl(returnUrl))
        //    {
        //        return Redirect(returnUrl);
        //    }
        //    else
        //    {
        //        return RedirectToAction(nameof(HomeController.Myprofile), "Home", new { area = "" });
        //    }
        //}
        #endregion
    }
}
