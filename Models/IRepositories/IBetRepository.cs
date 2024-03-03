using System.Collections.Generic;

namespace BetApp.Models.IRepositories
{
    public interface IBetRepository
    {
        bool Create(Bet bet);
        bool Update(Bet bet);
        bool Delete(int betID);
        IEnumerable<Bet> GetSpecificUserBets(int userID);
        Bet GetBetByID(int betID);
        IEnumerable<Bet> GetBets();
        bool CreateLike(Like like);
        bool CreateComment(Comment comment);
        IEnumerable<Comment> GetComments();
    }
}
