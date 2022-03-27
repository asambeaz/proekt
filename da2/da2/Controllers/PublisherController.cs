using da2.Data;
using da2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace da2.Controllers
{
    public class PublisherController : Controller
    {
        public IActionResult Index()
        {
            List<Publisher> publishers = DataService.GetPublishers();
            return View(publishers);
        }

        public IActionResult Create()
        {
            return View();
        }

        public RedirectToActionResult Add(string name, string country, int publisherworth)
        {
            if (name == null || country == null || publisherworth < 0)
            {
                return RedirectToAction(actionName: "Index", controllerName: "Error");
            }
            DataService.AddPublisher(name, country, publisherworth);
            return RedirectToAction(actionName: "Index");
        }

        public IActionResult Delete(int id)
        {

            if (!DataService.GetPublishers().Any(y => y.Id == id))
            {
                return RedirectToAction(actionName: "Index", controllerName: "Error");
            }
            return View(id);
        }

        public RedirectToActionResult Remove(int id, string password)
        {
            if (!DataService.GetPublishers().Any(c => c.Id == id))
            {
                return RedirectToAction(actionName: "Index", controllerName: "Error");
            }
            if (password == "password")
            {

                DataService.DeletePublisher(id);
            }
            return RedirectToAction(actionName: "Index");
        }

        public IActionResult Edit(int id)
        {
            if (!DataService.GetPublishers().Any(c => c.Id == id))
            {
                return RedirectToAction(actionName: "Index", controllerName: "Error");
            }
            return View(DataService.GetPublishers().FirstOrDefault(x => x.Id == id));
        }

        public RedirectToActionResult EditConfirmed(string name, string country, int publisherworth, string password, int id)
        {
            if (!DataService.GetPublishers().Any(c => c.Id == id) || name == null || country == null || publisherworth < 0)
            {
                return RedirectToAction(actionName: "Index", controllerName: "Error");
            }
            if (password == "password")
            {

                DataService.EditPublisher(id, name, country, publisherworth);
            }
            return RedirectToAction(actionName: "Index");
        }

        public IActionResult Details(int id)
        {
            if (!DataService.GetPublishers().Any(c => c.Id == id))
            {
                return RedirectToAction(actionName: "Index", controllerName: "Error");
            }
            return View(DataService.GetPublishers().FirstOrDefault(x => x.Id == id));
        }
    }
}