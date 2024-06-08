using JobForum3._0.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace JobForum3._0.Pages
{
    public class TopicsModel : PageModel
    {
        public Areas.Identity.Data.JobForum3_0User MyUser { get; set; }
        private UserManager<Areas.Identity.Data.JobForum3_0User> _userManager {  get; set; }
        private readonly Data.JobForum3_0Context _context;

        [BindProperty]
        public Models.Topic Topic { get; set; }
        public List<Models.Topic> TopicList { get; set; }

        [BindProperty]
        public Models.TopicResponse TopicResponse { get; set; }
        public List<Models.TopicResponse> TopicResponseList { get; set; }

        [BindProperty]
        public Models.Report Report { get; set; }

        public TopicsModel(UserManager<Areas.Identity.Data.JobForum3_0User> userManager, Data.JobForum3_0Context context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task OnGetAsync(int deleteTopicId, int deleteResponseId)
        {
            MyUser = await _userManager.GetUserAsync(User);

            if(deleteTopicId != 0)
            {
                Models.Topic topicToBeDeleted = await _context.Topic.FindAsync(deleteTopicId);
                _context.Topic.Remove(topicToBeDeleted);
                await _context.SaveChangesAsync();
            }

            if(deleteResponseId != 0)
            {
                Models.TopicResponse responseToBeDeleted = await _context.TopicResponse.FindAsync(deleteResponseId);
                _context.TopicResponse.Remove(responseToBeDeleted);
                await _context.SaveChangesAsync();
            }

            TopicList = await _context.Topic.ToListAsync();
            TopicResponseList = await _context.TopicResponse.ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync(int responseId, string reporterUserId, int topicId, string reporterName)
        {
            var report = new Report
            {
                ResponseId = responseId,
                ReporterUserId = reporterUserId,
                ReporterName  = reporterName,
                ReportedAt = DateTime.UtcNow,
                IsHandled = false
            };

            _context.Report.Add(report);

            var newResponse = new TopicResponse
            {
                UserId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                ResponseDate = DateTime.Now,
                TopicId = topicId,
                Name = TopicResponse.Name,
                Response = TopicResponse.Response
            };
            
            _context.TopicResponse.Add(newResponse);

            await _context.SaveChangesAsync();

            return RedirectToPage("./Topics");
        }
    }
}
