using Business.Abstract;
using Business.ValidationRules;
using Entity.Entities;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EState.UI.Areas.Admin.Controllers {
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdvertController : Controller {
        IAdvertService _advertService;
        ICityService _cityService;
        IDistrictService _districtService;
        INeighbourhoodService _neighbourhoodService;
        ISituationService _situationService;
        ITypeService _typeService;

        IWebHostEnvironment hostEnvironment;

        public AdvertController(IAdvertService advertService, ICityService cityService, IDistrictService districtService, INeighbourhoodService neighbourhoodService, ISituationService situationService, ITypeService typeService, IWebHostEnvironment hostEnvironment) {
            _advertService = advertService;
            _cityService = cityService;
            _districtService = districtService;
            _neighbourhoodService = neighbourhoodService;
            _situationService = situationService;
            _typeService = typeService;
            this.hostEnvironment = hostEnvironment;
        }

        public IActionResult Index() {
            string id = HttpContext.Session.GetString("id");

            var list = _advertService.List(x => x.Status == true && x.UserAdminId == id);
            return View(list);
        }
        public IActionResult Create() {
            ViewBag.userid = HttpContext.Session.GetString("Id");
            DropDown();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Advert data) {
            AdvertValidation validationRules = new AdvertValidation();
            ValidationResult result = validationRules.Validate(data);

            if (result.IsValid) {
                if (data.Image != null) {
                    var dosyayolu = Path.Combine(hostEnvironment.WebRootPath, "img");

                    foreach (var item in data.Image) {
                        var tamDosyaAdi = Path.Combine(dosyayolu, item.FileName);

                        using (var dosyaAkisi = new FileStream(tamDosyaAdi, FileMode.Create)) {
                            item.CopyTo(dosyaAkisi);
                        }
                        data.Images.Add(new Images { ImageName = item.FileName, Status = true });
                    }
                    _advertService.Add(data);

                    TempData["Success"] = "İlan Ekleneme İşlemi Başarı ile Gerçekleşti";
                    return RedirectToAction("Index");
                }
            }
            else {
                foreach (var item in result.Errors) {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            DropDown();
            return View();
        }
        public List<City> CityGet() {
            List<City> cityList = _cityService.List(x => x.Status == true);
            return cityList;
        }
        public List<Situation> SituationGet() {
            List<Situation> situationList = _situationService.List(x => x.Status == true);
            return situationList;
        }
        public List<Entity.Entities.Type> TypeGet() {
            List<Entity.Entities.Type> typeList = _typeService.List(x => x.Status == true);
            return typeList;
        }
        public List<Neighbourhood> NeighbourhoodGet() {
            List<Neighbourhood> neighbourhoodList = _neighbourhoodService.List(x => x.Status == true);
            return neighbourhoodList;
        }
        public List<District> DistrictGet() {
            List<District> districtList = _districtService.List(x => x.Status == true);
            return districtList;
        }

        public PartialViewResult DistrictPartial() {
            return PartialView();
        }
        public PartialViewResult TypePartial() {
            return PartialView();
        }
        public PartialViewResult NeighbourhoodPartial() {
            return PartialView();
        }
        public PartialViewResult CityPartial() {
            return PartialView();
        }
        public PartialViewResult SituationPartial() {
            return PartialView();
        }
        public IActionResult TypeGet(int TypeId) {
            List<Entity.Entities.Type> typeList = _typeService.List(x => x.Status == true && x.TypeId == TypeId);
            ViewBag.typeList = new SelectList(typeList, "TypeId", "TypeName");
            return PartialView("TypePartial");
        }
        public IActionResult DistrictGet(int DistrictId) {
            List<District> districtList = _districtService.List(x => x.Status == true && x.DistrictId == DistrictId);
            ViewBag.district = new SelectList(districtList, "DistrictId", "DistrictName");
            return PartialView("DistrictPartial");

        }
        public IActionResult NeighbourhoodGet(int NeigbourhoodId) {
            List<Neighbourhood> neighbourhoodList = _neighbourhoodService.List(x => x.Status == true && x.NeighbourhoodId == NeigbourhoodId);
            ViewBag.neighbourhoodList = new SelectList(neighbourhoodList, "NeighbourhoodId", "NeighbourhoodName");
            return PartialView("NeighbourhoodPartial");
        }
        public IActionResult CityGet(int CityId) {
            List<City> cityList = _cityService.List(x => x.Status == true && x.CityId == CityId);
            ViewBag.cityList = new SelectList(cityList, "CityId", "CityName");
            return PartialView("CityPartial");
        }
        public IActionResult SituationGet(int SituationId) {
            List<Situation> situationList = _situationService.List(x => x.Status == true && x.SituationId == SituationId);
            ViewBag.situationList = new SelectList(situationList, "SituationId", "SituationName");
            return PartialView("SituationPartial");
        }

        public void DropDown() {
            ViewBag.cityList = new SelectList(CityGet(), "CityId", "CityName");
            ViewBag.districtList = new SelectList(DistrictGet(), "DistrictId", "DistrictName");
            ViewBag.situationList = new SelectList(SituationGet(), "SituationId", "SituationName");
            ViewBag.neighbourhoodList = new SelectList(NeighbourhoodGet(), "NeighbourhoodId", "NeighbourhoodName");
            ViewBag.typeList = new SelectList(TypeGet(), "TypeId", "TypeName");
            
        }
    }
}
