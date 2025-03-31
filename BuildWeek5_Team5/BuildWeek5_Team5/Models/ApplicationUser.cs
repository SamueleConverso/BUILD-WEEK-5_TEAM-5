using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace BuildWeek5_Team5.Models {
    public class ApplicationUser : IdentityUser {
        [Required]
        public required string FirstName {
            get; set;
        }

        [Required]
        public required string LastName {
            get; set;
        }

        [Required]
        public DateOnly BirthDate {
            get; set;
        }

        public ICollection<ApplicationUserRole> ApplicationUserRoles {
            get; set;
        }
    }
}