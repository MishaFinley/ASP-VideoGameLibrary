using FinleyM_VGL.Data;
using FinleyM_VGL.Interfaces;
using FinleyM_VGL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using VideoGameDataAccessLibrary.Models;

namespace FinleyM_VGL.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        IDAL dal;

        public HomeController(IDAL dataAccessLayer)
        {
            dal = dataAccessLayer;
        }

        //private readonly ILogger<HomeController> _logger;
        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Games(IEnumerable<VideoGame> vg)
        {
            var userEmail = User.GetEmail();
            var userId = User.GetUserId();
            var username = User.GetUsername();
            return View("Privacy", dal.GetGames().Where(s => s.UserId == userId));
        }
        [HttpPost]
        public IActionResult Search(string key, string genre, string platform, string esrb)
        {
            IEnumerable<VideoGame> searchResult = dal.SearchForGames(User.GetUserId(), key, genre, platform, esrb);
            return View("Privacy", searchResult);
        }

        public IActionResult RemoveGame(int ID)
        {
            dal.RemoveGame(dal.GetGames().Find(p => p.Id == ID));
            return Redirect("/Home/Games");
        }

        public IActionResult AddGame()
        {
            return View("AddGame");
        }
        public IActionResult EditGame(int ID)
        {
            VideoGame vg = dal.GetGame(ID);
            return View("Edit", vg);
        }
        [HttpPost]
        public IActionResult EditGame(VideoGame game)
        {
            game.UserId = User.GetUserId();
            dal.UpdateVideoGame(game);

            return Redirect("/Home/Games");
            
        }
        [HttpPost]
        public IActionResult AddGame(string Title, string Platform, string Genre, string ESRB, int Year, string Image)
        {
            VideoGame vg = new VideoGame(User.GetUserId(), Title, Platform, Genre, ESRB, Year, Image, null, null, null);
            dal.AddGame(vg);
            return Redirect("/Home/Games");
        }
        [HttpPost]
        public IActionResult Loan(int ID, string LoanedTo, DateTime LoanDate)
        {
            //VideoGame vg = FindGame(ID);
            dal.GetGame(ID).LoanedTo = LoanedTo;
            dal.GetGame(ID).LoanDate = LoanDate;
            dal.UpdateVideoGame(dal.GetGame(ID));

            return Redirect("/Home/Games");
        }
        public IActionResult Loan(int ID)
        {
            VideoGame vg = dal.GetGame(ID);

            return View("Loan", vg);

        }
        public IActionResult Return(int ID)
        {
            dal.GetGame(ID).LoanedTo = null;
            dal.GetGame(ID).LoanDate = null;
            dal.UpdateVideoGame(dal.GetGame(ID));
            return Redirect("/Home/Games");
        }
        //public VideoGame FindGame(int ID)
        //{
        //    VideoGame FoundGame = null;

            
        //    foreach(var game in dal.GetGames())
        //    {
        //        if(game.ID == ID)
        //        {
        //            FoundGame = game;
        //        }
        //    }
        //    return FoundGame;
        //}


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
