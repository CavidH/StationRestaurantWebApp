using System;
using Microsoft.AspNetCore.Identity;

namespace Core.Entities
{
    public class ApplicationUser:IdentityUser
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public bool IsActivated { get; set; }
        public string Image { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
