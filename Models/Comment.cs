using BetApp.Models.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BetApp.Models
{
    public class Comment
    {
        [Key]
        public int ID { get; set; }
        public string Body { get; set; }

        [ForeignKey("AspNetUsers")]
        public int? UserID { get; set; }
        public virtual AppUser User { get; set; }

        [ForeignKey("Bets")]
        public int? BetID { get; set; }

        
    }
}
