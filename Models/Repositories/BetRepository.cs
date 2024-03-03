using BetApp.Data;
using BetApp.Models.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BetApp.Models.Repositories
{
    public class BetRepository : IBetRepository
    {
        private readonly ApplicationDbContext _context;

        public BetRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Create(Bet bet)
        {
            try
            {
                _context.Bets.Add(bet);
                _context.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {

                return false;
            }
        }

        public bool Delete(int betID)
        {
            try
            {
                Bet Bet = GetBetByID(betID);
                _context.Bets.Remove(Bet);
                _context.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {

                return false;
            }
        }

        public Bet GetBetByID(int betID)
        {
            Bet Bet = _context.Bets.SingleOrDefault(x => x.ID == betID);
            return Bet;
        }

        public IEnumerable<Bet> GetSpecificUserBets(int userID)
        {
            var userBets = _context.Bets.Where(x => x.UserID == userID);
            return userBets;
        }

        public bool Update(Bet Bet)
        {
            try
            {
                _context.Bets.Update(Bet);
                _context.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {

                return false;
            }
        }

        public IEnumerable<Bet> GetBets()
        {
            var Bets = _context.Bets.Include(x => x.User).ToList();
            return Bets;
        }

        public bool CreateLike(Like like)
        {
            try
            {
                _context.Likes.Add(like);
                _context.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {

                return false;
            }
        }

        public bool CreateComment(Comment comment)
        {
            try
            {
                _context.Comments.Add(comment);
                _context.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {

                return false;
            }
        }
		public List<Like> GetLikes()
		{
			var likes = _context.Likes.ToList() ;
			return likes;
		}
		public IEnumerable<Comment> GetComments()
        {
            var comments = _context.Comments.Include(x => x.User).ToList();
            return comments;
        }
    }
}
