using System.ComponentModel.DataAnnotations;

namespace FitnessBuddy.Models
{
    public class FeedBack
    {
        public int Id { get; set; }

        [Required]
        [StringLength(128)]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(128)]
        public string Email { get; set; }

        [Required]
        public string Message { get; set; }
    }
}