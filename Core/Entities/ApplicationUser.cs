using Microsoft.AspNetCore.Identity;

namespace Core.Entities
{
    public class ApplicationUser:IdentityUser
    {
        public string UserName { get; set; }
    }
}
