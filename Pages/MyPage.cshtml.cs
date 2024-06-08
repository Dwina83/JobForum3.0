using JobForum3._0.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Claims;

namespace JobForum3._0.Pages
{
    [Authorize(Roles = "User")]
    public class MyPageModel : PageModel
    {

        public Areas.Identity.Data.JobForum3_0User MyUser { get; set; }
        private UserManager<Areas.Identity.Data.JobForum3_0User> _userManager { get; set; }
        private readonly Data.JobForum3_0Context _context;

        [BindProperty]
        public Models.Message Message { get; set; }
        public List<Models.Message> Messages { get; set; }
        public MyPageModel(UserManager<Areas.Identity.Data.JobForum3_0User> userManager, Data.JobForum3_0Context context)
        {
            _userManager = userManager;
            _context = context;
        }
        public async Task OnGetAsync(int deleteMessage)
        {
            MyUser = await _userManager.GetUserAsync(User);

            if (MyUser != null)
            {
                Messages = _context.Message.Where(m => m.RecieverName == MyUser.Forename).ToList();
            }

            if(deleteMessage != 0)
            {
                Models.Message messageTobeDeleted = await _context.Message.FindAsync(deleteMessage);
                if (messageTobeDeleted != null)
                {
                    _context.Message.Remove(messageTobeDeleted);
                    await _context.SaveChangesAsync();
                }

            }
            


            Messages = await _context.Message.ToListAsync();

        }

        public async Task<IActionResult> OnPostAsync()
        {

            Message.SendDate = DateTime.Now;
           

            _context.Message.Add(Message);
            await _context.SaveChangesAsync();

          
            return RedirectToPage("/MyPage");
        }
    }
}
