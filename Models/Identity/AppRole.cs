using Microsoft.AspNetCore.Identity;

namespace BetApp.Models.Identity
{
    public class AppRole : IdentityRole<int>
    {
        public string Description { get; set; }
    }
}
