using da2.Data;
using da2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace da2.Controllers
{
    public class GenreController : Controller
    {
        public IActionResult Index()
        {
            List<Genre> genres = DataService.GetGenres();
            return View(genres);
        }

        public IActionResult Create()
        {
            return View();
        }

        public RedirectToActionResult Add(string name, int popularity, string ageGroup)
        {
            if (name == null || ageGroup == null || popularity < 0)
            {
                return RedirectToAction(actionName: "Index", controllerName: "Error");
            }
            DataService.AddGenre(name, popularity, ageGroup);
            return RedirectToAction(actionName: "Index");
        }

        public IActionResult Delete(int id)
        {

            if (!DataService.GetGenres().Any(y => y.Id == id))
            {
                return RedirectToAction(actionName: "Index", controllerName: "Error");
            }
            return View(id);
        }

        public RedirectToActionResult Remove(int id, string password)
        {
            if (!DataService.GetGenres().Any(c => c.Id == id))
            {
                return RedirectToAction(actionName: "Index", controllerName: "Error");
            }
            if (password == "password")
            {

                DataService.DeleteGenre(id);
            }
            return RedirectToAction(actionName: "Index");
        }

        public IActionResult Edit(int id)
        {
            if (!DataService.GetGenres().Any(c => c.Id == id))
            {
                return RedirectToAction(actionName: "Index", controllerName: "Error");
            }
            return View(DataService.GetGenres().FirstOrDefault(x => x.Id == id));
        }

        public RedirectToActionResult EditConfirmed(string name, string ageGroup, int popularity, string password, int id)
        {
            if (!DataService.GetGenres().Any(c => c.Id == id) || name == null || ageGroup == null || popularity < 0)
            {
                return RedirectToAction(actionName: "Index", controllerName: "Error");
            }
            if (password == "password")
            {

                DataService.EditGenre(id, name, ageGroup, popularity);
            }
            return RedirectToAction(actionName: "Index");
        }

        public IActionResult Details(int id)
        {
            if (!DataService.GetGenres().Any(c => c.Id == id))
            {
                return RedirectToAction(actionName: "Index", controllerName: "Error");
            }
            return View(DataService.GetGenres().FirstOrDefault(x => x.Id == id));
        }
    }
}