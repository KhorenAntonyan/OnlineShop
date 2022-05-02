using Microsoft.AspNetCore.Identity;

namespace OnlineShop.DAL.Entities
{
    public class User : IdentityUser
    {
        public int Year { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime ModifiedDate { get; set; }
    }
}
