namespace JobForum3._0.Models
{
    public class Topic
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Text { get; set; }
        public DateTime LastUpdated { get; set; }
        public string?  Author { get; set; }

    }
}
