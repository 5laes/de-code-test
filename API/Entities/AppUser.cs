using Microsoft.AspNetCore.Identity;

namespace API.Entities
{
    public class AppUser : IdentityUser
    {
        public ICollection<UserQuizAnswer> Answers { get; set; }
    }
}