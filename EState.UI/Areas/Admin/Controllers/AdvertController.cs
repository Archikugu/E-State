using Business.Abstract;
using Entity.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EState.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdvertController : Controller
    {
        IAdvertService _advertService;
        ICityService _cityService;
        IDistrictService _districtService;
        INeighbourhoodService _neighbourhoodService;
        ISituationService _situationService;
        ITypeService _typeService;

        public AdvertController(IAdvertService advertService, ICityService cityService, IDistrictService districtService, INeighbourhoodService neighbourhoodService, ISituationService situationService, ITypeService typeService)
        {
            _advertService = advertService;
            _cityService = cityService;
            _districtService = districtService;
            _neighbourhoodService = neighbourhoodService;
            _situationService = situationService;
            _typeService = typeService;
        }

        public IActionResult Index()
        {
            string id = HttpContext.Session.GetString("id");

            var list = _advertService.List(x => x.Status == true && x.UserAdminId == id);
            return View(list);
        }
        public IActionResult Create()
        {
            return View();
        }
        public List<City> CityGet()
        {
            List<City> cities = _cityService.List(x => x.Status == true);
            return cities;
        }
        public List<Situation> SituationGet()
        {
            List<Situation> situations = _situationService.List(x => x.Status == true);
            return situations;
        }
        public PartialViewResult DistrictPartial()
        {
            return PartialView();
        }
        public PartialViewResult TypePartial()
        {
            return PartialView();
        }
        public PartialViewResult NeighbourhoodPartial()
        {
            return PartialView();
        }
        public IActionResult TypeGet(int id)
        {
            List<Entity.Entities.Type> typeList = _typeService.List(x => x.Status == true && x.TypeId == id);
            ViewBag.type = new SelectList(typeList, "TypeId", "TypeName");
            return PartialView("TypePartial");
        }
        public IActionResult DistrictGet(int id)
        {
            List<District> districtList = _districtService.List(x => x.Status == true && x.CityId == id);
            ViewBag.district = new SelectList(districtList, "DistrictId", "DistrictName");
            return PartialView("DistrictPartial");

        }
        public IActionResult NeighbourhoodGet(int id)
        {
            List<Neighbourhood> neighbourhoodList = _neighbourhoodService.List(x => x.Status == true && x.DistrictId == id);
            ViewBag.neighbourhood = new SelectList(neighbourhoodList, "NeighbourhoodId", "NeighbourhoodName");
            return PartialView("NeighbourhoodPartial");

        }
        public void DropDown()
        {
            ViewBag.cityList = new SelectList(CityGet(), "CityId", "CityName");
            ViewBag.situations = new SelectList(CityGet(), "SituationId", "SituationName");
        }
    }
}
