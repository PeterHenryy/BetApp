using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BetApp.Models
{
    public class Like
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("AspNetUsers")]
        public int? UserID { get; set; }
        [ForeignKey("Bets")]
        public int? BetID { get; set; }

    }
}
