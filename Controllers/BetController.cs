using BetApp.Migrations;
using BetApp.Models;
using BetApp.Models.Identity;
using BetApp.Models.ViewModels;
using BetApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BetApp.Controllers
{
    public class BetController : Controller
    {
        private readonly BetService _betService;
        private readonly UserService _userService;
        private readonly AppUser _currentUser;

        public BetController(BetService BetService, UserService userService)
        {
            _betService = BetService;
            _userService = userService;
            _currentUser = userService.GetCurrentUser();
        }

        public IActionResult Index()
		{
			BetIndexViewModel betIndexViewModel = new BetIndexViewModel();
            betIndexViewModel.Bets = _betService.GetBets(); 
            betIndexViewModel.Likes = _betService.GetLikes();
            betIndexViewModel.Comments = _betService.GetComments();
            betIndexViewModel.CurrentUser = _currentUser;
            return View(betIndexViewModel);
        }


        [HttpGet]
        public IActionResult GetComments(int betID)
        {
            var comments = _betService.GetComments().Where(x => x.BetID == betID);
            return Json(comments);
        }

		public IActionResult UserBets()
        {
            
            var userBets = _betService.GetUserBets(_currentUser.Id);
            return View(userBets);
        }

        [HttpPost]
        public IActionResult Create(BetIndexViewModel betViewModel)
        {
            AppUser user = _userService.GetCurrentUser();
            betViewModel.Bet.UserID = user.Id;
            var files = HttpContext.Request.Form.Files;
            if (files.Count > 0)
            {
                betViewModel.Bet.Image = files[0].FileName;
                _betService.HandleBetImage(files);
            }
            bool createdBet = _betService.Create(betViewModel.Bet);
            if (createdBet)
            {
                return RedirectToAction("Index", "Bet");
            }
            return View(betViewModel);
        }

        [HttpGet]
        public IActionResult Update(int betID)
        {
            Bet Bet = _betService.GetBetByID(betID);
            return View(Bet);
        }

        [HttpPost]
        public IActionResult Update(Bet bet)
        {
            bool updatedBet = _betService.Update(bet);
            if (updatedBet)
            {
                return RedirectToAction("Index", "Bet");
            }
            return View(bet);
        }

        public IActionResult Delete(int betID)
        {
            Bet Bet = _betService.GetBetByID(betID);
            bool deletedBet = _betService.Delete(betID);
            return RedirectToAction("Index", "Bet");
        }

        [HttpPost]
        public IActionResult CreateLike(BetIndexViewModel betIndexViewModel)
        {
            Like like = new Like();
            like.BetID = betIndexViewModel.Bet.ID;
			like.UserID = _currentUser.Id;
            bool createdLike = _betService.CreateLike(like);
            return RedirectToAction("Index", "Bet");
        }

        [HttpPost]
        public IActionResult CreateComment(BetIndexViewModel betIndexViewModel)
        {
            Comment comment = betIndexViewModel.Comment;
			AppUser user = _userService.GetCurrentUser();

			comment.UserID = user.Id;
            bool createdComment = _betService.CreateComment(comment);
            return RedirectToAction("Index", "Bet");
        }


    }
}
