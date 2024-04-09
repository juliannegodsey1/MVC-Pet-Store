using Microsoft.AspNetCore.Mvc;
using PetStoreCRUDWebsite.Models;

namespace PetStoreCRUDWebsite.Controllers
{
    public class CatController : Controller
    {
        private readonly ICatRepository repo;

        public CatController(ICatRepository repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            var cats = repo.GetAllCats();
            return View(cats);
        }

        public IActionResult ViewCat(int id)
        {
            var cat = repo.GetCat(id);
            return View(cat);
        }

        public IActionResult UpdateCat(int id)
        {
            Cat cat = repo.GetCat(id);
            if (cat == null)
            {
                return View("CatNotFound");
            }
            return View(cat);
        }


        public IActionResult UpdateCatToDatabase(Cat cat)
        {
            repo.UpdateCat(cat);

            return RedirectToAction("ViewCat", new { id = cat.PetID });
        }


        public IActionResult InsertCat(Cat cat)
        {
            return View(cat);
        }


        public IActionResult InsertCatToDatabase(Cat catToInsert)
        {
            repo.InsertCat(catToInsert);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteCat(Cat cat)
        {
            repo.DeleteCat(cat);
            return RedirectToAction("Index");
        }



    }
}
