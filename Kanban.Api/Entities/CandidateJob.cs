namespace Kanban.Api.Entities
{
    public class CandidateJob
    {
        public int Id { get; set; }
        public int CandidateId { get; set; }
        public int JobId { get; set; }
        public Candidate Candidate { get; set; }
        public Job Job { get; set; }
    }
}