using Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EState.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdvertController : Controller
    {
        IAdvertService _advertService;

        public AdvertController(IAdvertService advertService)
        {
            _advertService = advertService;
        }

        public IActionResult Index()
        {
            string id = HttpContext.Session.GetString("id");

            var list = _advertService.List(x => x.Status == true && x.UserAdminId == id);
            return View(list);
        }
    }
}
