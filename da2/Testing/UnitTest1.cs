using da2.Controllers;
using da2.Data;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System.Linq;

namespace Testing
{
    public class Genres
    {
        [Test]
        public void DataBaseTest()
        {
            DataService.AddGenre("1", 1, "1");
            DataService.AddGenre("2", 2, "2");
            DataService.AddGenre("3", 3, "3");

            Assert.AreEqual("3", DataService.GetGenres().Last().Name);
            DataService.DeleteGenre(DataService.GetGenres().Last().Id);

            Assert.AreEqual(1000, DataService.GetGenres().Last().Popularity);
            DataService.DeleteGenre(DataService.GetGenres().Last().Id);

            Assert.AreEqual("3", DataService.GetGenres().Last().AgeGroup);
            DataService.DeleteGenre(DataService.GetGenres().Last().Id);

            DataService.AddGenre("1", 1, "1");
            DataService.EditGenre(DataService.GetGenres().Last().Id, "3", "3", 3);
            Assert.AreEqual("3", DataService.GetGenres().Last().Name);
            DataService.DeleteGenre(DataService.GetGenres().Last().Id);
        }

        [Test]
        public void DetailsShouldRedirectToErrorPageOnInvalidId()
        {
            GenreController cntr = new GenreController();
            var result = cntr.Details(-1) as RedirectToActionResult;
            Assert.AreEqual("Error", result.ControllerName);
        }

        [Test]
        public void DetailsShouldRedirectToViewOnValidId()
        {
            DataService.AddGenre("2", 2, "2");
            GenreController cntr = new GenreController();
            int id = DataService.GetGenres().Last().Id;
            var result = cntr.Details(id) as ViewResult;
            Assert.IsNotNull(result);
            DataService.DeleteGenre(DataService.GetGenres().Last().Id);
        }

        [Test]
        public void AddShouldRedirectToErrorPageOnInvalidId()
        {
            DataService.AddGenre("3", 3, "3");
            GenreController cntr = new GenreController();
            cntr.Add(name: null, popularity: 1, ageGroup: "1");
            Assert.AreEqual("3", DataService.GetGenres().Last().Popularity);

            var result = cntr.Add(name: "1", popularity: 0, ageGroup: "1") as RedirectToActionResult;
            Assert.AreEqual("Error", result.ControllerName);

            result = cntr.Add("1", -1, "1") as RedirectToActionResult;
            Assert.AreEqual("Error", result.ControllerName);
            DataService.DeleteGenre(DataService.GetGenres().Last().Id);

        }

        [Test]
        public void AddShouldCreateItem()
        {
            GenreController cntr = new GenreController();
            cntr.Add("1", 1, "1");
            Assert.AreEqual("1", DataService.GetGenres().Last().Name);
            DataService.DeleteGenre(DataService.GetGenres().Last().Id);
        }

        [Test]
        public void EditConfirmedShouldRedirectToErrorPageOnInvalidInput()
        {
            DataService.AddGenre("2", 2, "2");
            int id = DataService.GetGenres().Last().Id;
            GenreController cntr = new GenreController();
            var result = cntr.EditConfirmed(id: id, name: null, popularity: 1, password: "password", ageGroup: "1") as RedirectToActionResult;
            Assert.AreEqual("Error", result.ControllerName);

            result = cntr.EditConfirmed(id: id, name: "1", popularity: -1, password: "password", ageGroup: "1") as RedirectToActionResult;
            Assert.AreEqual("Error", result.ControllerName);

            result = cntr.EditConfirmed(id: id, name: "1", popularity: 1, password: "password", ageGroup: null) as RedirectToActionResult;
            Assert.AreEqual("Error", result.ControllerName);

            DataService.DeleteGenre(DataService.GetGenres().Last().Id);
        }

        [Test]
        public void EditShouldRedirectToViewOnValidId()
        {
            DataService.AddGenre("2", 2, "2");
            GenreController cntr = new GenreController();
            int id = DataService.GetGenres().Last().Id;
            cntr.EditConfirmed(id: id, name: "1", popularity: 1, password: "password", ageGroup: "1");
            Assert.AreEqual("1", DataService.GetGenres().Last().Name);
            DataService.DeleteGenre(id);
        }

        [Test]
        public void EditWrongPasswordShouldNotChangeItem()
        {
            DataService.AddGenre("2", 2, "2");
            GenreController cntr = new GenreController();
            int id = DataService.GetGenres().Last().Id;
            cntr.EditConfirmed(id: id, name: "1", popularity: 1, password: "passord", ageGroup: "1");
            Assert.AreEqual("2", DataService.GetGenres().Last().Name);
            DataService.DeleteGenre(id);
        }

        [Test]
        public void RemoveWrongPasswordShouldNotChangeItem()
        {
            DataService.AddGenre("2", 2, "2");
            DataService.AddGenre("1", 1, "1");
            GenreController cntr = new GenreController();
            int id = DataService.GetGenres().Last().Id;
            cntr.Remove(id: id, password: "passord");
            Assert.AreEqual("1", DataService.GetGenres().Last().Name);
            DataService.DeleteGenre(id);
            DataService.DeleteGenre(id - 1);
        }

        [Test]
        public void ValidRemoveShouldDeleteItem()
        {
            DataService.AddGenre("2", 2, "2");
            DataService.AddGenre("1", 1, "1");
            GenreController cntr = new GenreController();
            int id = DataService.GetGenres().Last().Id;
            cntr.Remove(id: id, password: "password");
            Assert.AreEqual("2", DataService.GetGenres().Last().Name);
            DataService.DeleteGenre(id - 1);
        }
        [Test]
        public void RemoveWithInvalidIdShouldRedirectToError()
        {
            DataService.AddGenre("2", 2, "2");
            int id = DataService.GetGenres().Last().Id;
            GenreController cntr = new GenreController();
            var result = cntr.Remove(id: -1, password: "password") as RedirectToActionResult;
            Assert.AreEqual("Error", result.ControllerName);
            DataService.DeleteGenre(id);
        }
        [Test]
        public void DeleteWithInvalidIdShouldRedirectToError()
        {
            GenreController cntr = new GenreController();
            var result = cntr.Delete(-1) as RedirectToActionResult;
            Assert.AreEqual("Error", result.ControllerName);
        }

    }
}