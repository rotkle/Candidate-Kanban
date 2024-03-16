using System.ComponentModel.DataAnnotations;

namespace Kanban.Api.Models
{
    public class CandidateRequestDto
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public int StatusId { get; set; }

        public List<int>? JobIds { get; set; }
    }
}