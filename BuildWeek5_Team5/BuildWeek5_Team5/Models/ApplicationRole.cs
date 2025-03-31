using Microsoft.AspNetCore.Identity;

namespace BuildWeek5_Team5.Models {
    public class ApplicationRole : IdentityRole {
        public ICollection<ApplicationUserRole> ApplicationUserRole {
            get; set;
        }
    }
}
