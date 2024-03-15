namespace Kanban.Api.Entities
{
    public class Job
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<CandidateJob> CandidateJobs { get; set; }
    }
}