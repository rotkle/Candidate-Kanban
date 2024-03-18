using System.ComponentModel.DataAnnotations;

namespace Kanban.Api.Models
{
    /// <summary>
    /// Candidate request dto contain Candidate data which will be used for create/update Candidate requests
    /// </summary>
    public class CandidateRequestDto
    {
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        [Required]
        [Phone]
        [MaxLength(30)]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(200)]
        public string Email { get; set; }

        [Required]
        public int StatusId { get; set; }

        public List<int>? JobIds { get; set; }
    }
}