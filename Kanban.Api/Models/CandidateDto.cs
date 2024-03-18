namespace Kanban.Api.Models
{
    /// <summary>
    /// Candidate dto contain Candidate data which will be return when get Candidate requests is called
    /// </summary>
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