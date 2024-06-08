namespace JobForum3._0.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string? Header { get; set; }
        public string? Author { get; set; }
        public string? Description { get; set; }
        public DateTime DatePosted { get; set; }
        public string? FileUpload { get; set; }
    }
}
