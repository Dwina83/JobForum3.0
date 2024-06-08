namespace JobForum3._0.Models
{
    public class Report
    {
        public int Id { get; set; }
        public int ResponseId { get; set; }
        public string? ReporterUserId { get; set; }
        public string? ReporterName { get; set; }
        public DateTime ReportedAt { get; set; }
        public bool IsHandled { get; set; }

    }
}
