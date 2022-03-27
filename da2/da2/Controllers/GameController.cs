using da2.Data;
using da2.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameController.Controllers
{
    public class GameController : Controller
    {
        public IActionResult Create()
        {
            GamesAndGenresAndPlatformsAndPublishers x = new GamesAndGenresAndPlatformsAndPublishers();
            x.Genres = DataService.GetGenres();
            x.Platforms = DataService.GetPlatforms();
            x.Publishers = DataService.GetPublishers();

            return View(x);
        }

        public RedirectToActionResult Add(string Name, int GenreId, int PublisherId, double Price, double Rating, int PlatformId, bool isMultiplayer)
        {
             if (Name == null || Rating < 0 || Price < 0 || !DataService.GetGenres().Any(y => y.Id == GenreId) || !DataService.GetPlatforms().Any(y => y.Id == PlatformId) || !DataService.GetPublishers().Any(y => y.Id == PublisherId))
            {
                return RedirectToAction(actionName: "Index", controllerName: "Error");
            }
            DataService.AddGame(Name, Rating, Price, GenreId, PlatformId, PublisherId, isMultiplayer);
            return RedirectToAction(actionName: "Index");
        }

        public IActionResult Index()
        {
            List<Platform> platforms = DataService.GetPlatforms();
            List<Genre> genres = DataService.GetGenres();
            List<Publisher> publishers = DataService.GetPublishers();
            List<Game> games = new List<Game>(DataService.GetGames());
            games.ForEach(x =>
            {
                x.Platform = platforms.FirstOrDefault(y => y.Id == x.PlatformId);
                x.Genre = genres.FirstOrDefault(y => y.Id == x.GenreId);
                x.Publisher = publishers.FirstOrDefault(y => y.Id == x.PublisherId);
            });

            return View(games);
        }

        public IActionResult Details(int id)
        {
            if (!DataService.GetGames().Any(y => y.Id == id))
            {
                return RedirectToAction(actionName: "Index", controllerName: "Error");
            }
            List<Genre> genres = DataService.GetGenres();
            List<Publisher> publishers = DataService.GetPublishers();
            List<Platform> platforms = DataService.GetPlatforms();
            Game game = DataService.GetGames().FirstOrDefault(x => x.Id == id);
            game.Genre = genres.FirstOrDefault(y => y.Id == game.GenreId);
            game.Publisher = publishers.FirstOrDefault(y => y.Id == game.PublisherId);
            game.Platform = platforms.FirstOrDefault(y => y.Id == game.PlatformId);


            return View(game);
        }

        public IActionResult Edit(int id)
        {
            GamesAndGenresAndPlatformsAndPublishers x = new GamesAndGenresAndPlatformsAndPublishers();
            if (!DataService.GetGames().Any(y => y.Id==id))
            {
                return RedirectToAction(actionName: "Index", controllerName: "Error");
            }
            x.game = DataService.GetGames().FirstOrDefault(y => y.Id == id);
            x.Genres = DataService.GetGenres();
            x.Platforms = DataService.GetPlatforms();
            x.Publishers = DataService.GetPublishers();

            return View(x);
        }

        public RedirectToActionResult ConfirmEdit(int id, string name, int platform, double rating, int publisher, int genre, bool isMultiplayer, double price, string password)
        {
            if (password == "password")
            {
                if (name == null || price < 0 || rating < 0 || !DataService.GetGenres().Any(y => y.Id == genre) || !DataService.GetPublishers().Any(y => y.Id == publisher) || !DataService.GetPlatforms().Any(y => y.Id == platform))
                {
                    Console.WriteLine(name);
                    Console.WriteLine(price);
                    Console.WriteLine(rating);
                    Console.WriteLine(genre);
                    Console.WriteLine(publisher);
                    Console.WriteLine(platform);
                    return RedirectToAction(actionName: "Index", controllerName: "Error");
                }
                DataService.EditGame(id, name, platform, rating, publisher, genre, isMultiplayer, price);
            }
            return RedirectToAction(actionName: "Index");
        }

        public IActionResult Delete(int id)
        {

            if (!DataService.GetGames().Any(y => y.Id == id))
            {
                return RedirectToAction(actionName: "Index", controllerName: "Error");
            }
            Game game = DataService.GetGames().FirstOrDefault(x => x.Id == id);
            return View(game);
        }

        public RedirectToActionResult Remove(int id, string password)
        {
            if (password == "password")
            {
                if (!DataService.GetGames().Any(y => y.Id == id))
                {
                    return RedirectToAction(actionName: "Index", controllerName: "Error");
                }
                DataService.DeleteGame(id);
            }
            return RedirectToAction(actionName: "Index");
        }
    }
}
