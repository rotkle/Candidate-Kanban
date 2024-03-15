namespace Kanban.Api.Entities
{
    public class Candidate
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public Status Status { get; set; }
        public int StatusId { get; set; }
        public ICollection<CandidateJob> CandidateJobs { get; set; }
    }
}