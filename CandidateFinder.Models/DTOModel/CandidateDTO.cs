using System.ComponentModel.DataAnnotations;

namespace CandidateFinder.Models
{
    public class CandidateDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required")]
        [StringLength(50, ErrorMessage = "String too long cannot exceed 50 characters.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Required")]
        [StringLength(50, ErrorMessage = "String too long cannot exceed 50 characters.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Required")]
        [StringLength(50, ErrorMessage = "String too long cannot exceed 50 characters.")]
        [EmailAddress(ErrorMessage ="Invalid formate")]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string PreferredCallTime { get; set; }
        public string LinkedInUrl { get; set; }
        public string GitHubUrl { get; set; }
        public string Comment { get; set; }
    }
}
