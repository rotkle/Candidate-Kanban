namespace Kanban.Api.Models
{
    /// <summary>
    /// Status dto contain Status data which will be return when get Status requests is called
    /// </summary>
    public class StatusDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}