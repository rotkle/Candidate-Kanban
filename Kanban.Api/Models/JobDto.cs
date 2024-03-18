namespace Kanban.Api.Models
{
    /// <summary>
    /// Job dto contain Job data which will be return when get Job requests is called
    /// </summary>
    public class JobDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}