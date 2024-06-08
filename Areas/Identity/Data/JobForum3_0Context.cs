using JobForum3._0.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using JobForum3._0.Models;

namespace JobForum3._0.Data;

public class JobForum3_0Context : IdentityDbContext<JobForum3_0User>
{
    public JobForum3_0Context(DbContextOptions<JobForum3_0Context> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

    public DbSet<Models.Topic> Topic { get; set; }

    public DbSet<JobForum3._0.Models.Article> Article { get; set; }

    
    public DbSet<JobForum3._0.Models.TopicResponse> TopicResponse { get; set; }

    public DbSet<JobForum3._0.Models.Report> Report { get; set; }

    public DbSet<JobForum3._0.Models.Message> Message { get; set; }

}
