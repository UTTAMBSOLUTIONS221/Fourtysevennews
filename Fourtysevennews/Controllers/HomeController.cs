using Fourtysevennews.Models;
using Fourtysevennews.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Fourtysevennews.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        private readonly Fourtysevennewsservices bl;
        public HomeController(IConfiguration config)
        {
            bl = new Fourtysevennewsservices(config);
        }


        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Index(int Page = 0, int PageSize = 10, string? Category = "")
        {
            var data = await bl.GetSystemfortysevennewsblogdata(Page, PageSize, Category);
            return View(data);
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Blogdetaildata(long Systemblogid)
        {
            var data = await bl.Getsystemfortysevennewsblogdetaildatabyid(Systemblogid);
            return View(data);
        }
        #region User Profile
        [HttpGet]
        public IActionResult Myprofile()
        {
            return View();
        }
        #endregion


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
