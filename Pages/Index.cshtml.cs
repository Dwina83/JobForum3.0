using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace JobForum3._0.Pages
{
    public class IndexModel : PageModel
    {
        public Areas.Identity.Data.JobForum3_0User MyUser { get; set; }

        private UserManager<Areas.Identity.Data.JobForum3_0User> _userManager { get; set; }

        private readonly Data.JobForum3_0Context _context;

        [BindProperty]
        public Models.Topic Topic { get; set; }
        public List<Models.Topic> TopicList { get; set; }

        [BindProperty]
        public Models.Article Article { get; set; }
        public List<Models.Article> ArticleList { get; set; }

        [BindProperty]
        public Models.TopicResponse TopicResponse { get; set; }
        public List<Models.TopicResponse> TopicResponseList { get; set; }

        public IndexModel(UserManager<Areas.Identity.Data.JobForum3_0User> userManager, Data.JobForum3_0Context context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task OnGetAsync(int deleteId)
        {
            MyUser = await _userManager.GetUserAsync(User);

            if (deleteId != 0)
            {
                Models.Topic topicToBeDeleted = await _context.Topic.FindAsync(deleteId);
                _context.Topic.Remove(topicToBeDeleted);
                await _context.SaveChangesAsync();
            }

            TopicList = await _context.Topic.ToListAsync();
            TopicResponseList = await _context.TopicResponse.ToListAsync();

            ArticleList = await _context.Article.ToListAsync();
        }


    }
}
