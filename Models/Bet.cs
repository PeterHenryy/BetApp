using BetApp.Models.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace BetApp.Models
{
    public class Bet
    {
        [Key]
        public int ID { get; set; }
        public string Body { get; set; }
        public string Image { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        [ForeignKey("AspNetUsers")]
        public int? UserID { get; set; }
        public virtual AppUser User { get; set; }
    }
}
