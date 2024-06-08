namespace JobForum3._0.Models
{
    public class TopicResponse
    {
        public int Id { get; set; }
        public string? Response { get; set; }
        public string? UserId { get; set; }
        public DateTime ResponseDate { get; set; }
        public int TopicId { get; set; }
        public string? Name { get; set; }

     
    }
}
