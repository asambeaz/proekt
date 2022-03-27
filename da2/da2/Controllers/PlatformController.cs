using da2.Data;
using da2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace da2.Controllers
{
    public class PlatformController : Controller
    {
        public IActionResult Index()
        {
            List<Platform> platforms = DataService.GetPlatforms();
            return View(platforms);
        }

        public IActionResult Create()
        {
            return View();
        }

        public RedirectToActionResult Add(string name, int numberOfUsers)
        {
            if (name == null || numberOfUsers < 0)
            {
                return RedirectToAction(actionName: "Index", controllerName: "Error");
            }
            DataService.AddPlatform(name, numberOfUsers);
            return RedirectToAction(actionName: "Index");
        }
        public IActionResult Delete(int id)
        {

            if (!DataService.GetPlatforms().Any(y => y.Id == id))
            {
                return RedirectToAction(actionName: "Index", controllerName: "Error");
            }
            return View(id);
        }

        public RedirectToActionResult Remove(int id, string password)
        {
            if (!DataService.GetPlatforms().Any(c => c.Id == id))
            {
                return RedirectToAction(actionName: "Index", controllerName: "Error");
            }
            if (password == "password")
            {

                DataService.DeletePlatform(id);
            }
            return RedirectToAction(actionName: "Index");
        }

        public IActionResult Edit(int id)
        {
            if (!DataService.GetPlatforms().Any(c => c.Id == id))
            {
                return RedirectToAction(actionName: "Index", controllerName: "Error");
            }
            return View(DataService.GetPlatforms().FirstOrDefault(x => x.Id == id));
        }

        public RedirectToActionResult EditConfirmed(string name, int numberOfUsers, string password, int id)
        {
            if (!DataService.GetPlatforms().Any(c => c.Id == id) || name == null || numberOfUsers < 0)
            {
                return RedirectToAction(actionName: "Index", controllerName: "Error");
            }
            if (password == "password")
            {
                DataService.EditPlatform(id, name, numberOfUsers);
            }
            return RedirectToAction(actionName: "Index");
        }

        public IActionResult Details(int id)
        {
            if (!DataService.GetPlatforms().Any(c => c.Id == id))
            {
                return RedirectToAction(actionName: "Index", controllerName: "Error");
            }
            return View(DataService.GetPlatforms().FirstOrDefault(x => x.Id == id));
        }
    }
}