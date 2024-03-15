namespace Kanban.Api.Models
{
    public class CandidateDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public StatusDto Status { get; set; }
        public List<JobDto> Jobs { get; set; }
    }
}