using Covid19Management.Models;
using Covid19Management.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Covid19Management.Controllers
{
    public class VaccinationController : Controller
    {
        private readonly ICitizenRepository _citizenRepository;
        private readonly IVacxinRepository _vacxinRepository;
        private readonly IVacxinTypeRepository _vacxinTypeRepository;
        private readonly IVaccinationRepository _vaccinationRepository;
        public VaccinationController(ICitizenRepository citizenRepository, IVacxinRepository vacxinRepository, IVacxinTypeRepository vacxinTypeRepository, IVaccinationRepository vaccinationRepository)
        {
            _citizenRepository = citizenRepository;
            _vacxinRepository = vacxinRepository;
            _vacxinTypeRepository = vacxinTypeRepository;
            _vaccinationRepository = vaccinationRepository;
        }

        //[Authorize]
        public IActionResult Index()
        {
            return View("Index", _vaccinationRepository.GetAllVaccinations().AsQueryable().Include(v => v.Citizen).ToList());
        }

        //[Authorize]
        public IActionResult Details(string code)
        {
            var vaccination = _vaccinationRepository.Find(code);
            if (vaccination == null)
            {
                return NotFound();
            }

            return View(vaccination);
        }

        //[Authorize(Roles = "Contributor,BlogOwner")]
        public IActionResult Create()
        {
            ViewData["CitizenCode"] = new SelectList(_citizenRepository.GetAllCitizens(), "CitizenCode", "Name");
            ViewData["VacxinCode"] = new SelectList(_vacxinRepository.GetAllVacxins(), "VacxinCode", "VacxinCode");
            return View(new Vaccination());
        }

        //[Authorize(Roles = "Contributor,BlogOwner")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Vaccination vaccination)
        {
            if (ModelState.IsValid)
            {
                _vaccinationRepository.AddVaccination(vaccination);
                return RedirectToAction(nameof(Index));
            }
            return View(vaccination);
        }

        //[Authorize(Roles = "Contributor,BlogOwner")]
        //public IActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var category = _categoryRepository.Find((int)id);
        //    if (category == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(category);
        //}

        //[Authorize(Roles = "Contributor,BlogOwner")]
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Edit(Category category)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _categoryRepository.UpdateCategory(category);
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (_postRepository.FindPost(category.Id) == null)
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(category);
        //}

        //[Authorize(Roles = "BlogOwner")]
        //public IActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var category = _categoryRepository.Find((int)id);
        //    if (category == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(category);
        //}

        //[Authorize(Roles = "BlogOwner")]
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public IActionResult DeleteConfirmed(int id)
        //{
        //    var category = _categoryRepository.Find(id);
        //    if (category != null)
        //    {
        //        _categoryRepository.DeleteCategory(category);
        //    }

        //    return RedirectToAction(nameof(Index));
        //}
    }
}
