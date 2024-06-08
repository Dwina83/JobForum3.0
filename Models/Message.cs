namespace JobForum3._0.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string? UserId { get; set; }
        public string? SenderName { get; set;}
        public string? RecieverName { get;set; }
        public string? Content { get; set; }
        public DateTime SendDate { get; set; }
    }
}
