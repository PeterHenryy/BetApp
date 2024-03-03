using BetApp.Models;
using BetApp.Models.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IO;

namespace BetApp.Services
{
    public class BetService
    {
        private readonly BetRepository _betRepos;
        private readonly IWebHostEnvironment _environment;

        public BetService(BetRepository BetRepos, IWebHostEnvironment environment)
        {
            _betRepos = BetRepos;
            _environment = environment;
        }

        public bool Create(Bet bet)
        {
            bool createdBet = _betRepos.Create(bet);
            return createdBet;
        }

        public bool Delete(int betID)
        {
            bool deletedBet = _betRepos.Delete(betID);
            return deletedBet;
        }

        public bool Update(Bet bet)
        {
            bool updatedBet = _betRepos.Update(bet);
            return updatedBet;
        }

        public IEnumerable<Bet> GetUserBets(int userID)
        {
            var userBets = _betRepos.GetSpecificUserBets(userID);
            return userBets;
        }

        public Bet GetBetByID(int betID)
        {
            Bet Bet = _betRepos.GetBetByID(betID);
            return Bet;
        }

        public IEnumerable<Bet> GetBets()
        {
            var Bets = _betRepos.GetBets();
            return Bets;
        }

        public bool CreateLike(Like like)
        {
            bool createdLike = _betRepos.CreateLike(like);
            return createdLike;
        }

        public bool CreateComment(Comment comment)
        {
            bool createdComment = _betRepos.CreateComment(comment);
            return createdComment;
        }

        public IEnumerable<Comment> GetComments()
        {
            var comments = _betRepos.GetComments();
            return comments;
        }
		public IEnumerable<Like> GetLikes()
		{
			var likes = _betRepos.GetLikes();
			return likes;
		}
		public void HandleBetImage(IFormFileCollection files)
        {
            var path = Path.Combine(_environment.WebRootPath, "bets") + "/" + files[0].FileName;
            using (FileStream fs = System.IO.File.Create(path))
            {
                files[0].CopyTo(fs);
                fs.Flush();
            }
        }
    }
}
