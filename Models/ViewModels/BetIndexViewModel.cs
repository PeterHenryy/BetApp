using BetApp.Migrations;
using BetApp.Models;
using BetApp.Models.Identity;
using System.Collections.Generic;
using System.Linq;

namespace BetApp.Models.ViewModels
{
    public class BetIndexViewModel
    {
        public IEnumerable<Bet> Bets { get; set; }
        public Bet Bet { get; set; }
        public Comment Comment { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
		public IEnumerable<Like> Likes { get; set; }
        public AppUser CurrentUser { get; set; }
        public int GetCommentCounter(int betID)
        {
            var betComments =  Comments.Where(x => x.BetID == betID);
            return betComments.Count();
		}
		public int GetBetLikes(int betID)
		{
			var betLikesCount = Likes.Where(x => x.BetID == betID).Count();
			return betLikesCount;
		}

		public bool HasUserLikedBet(int userID, int betID)
		{
			Like userLike = Likes.Where(x => x.BetID == betID).SingleOrDefault(x => x.UserID == userID);
			return userLike != null;

		}
	} 
}
 