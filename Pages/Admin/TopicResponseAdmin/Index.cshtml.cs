using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using JobForum3._0.Data;
using JobForum3._0.Models;
using Microsoft.AspNetCore.Authorization;

namespace JobForum3._0.Pages.Admin.TopicResponseAdmin
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly JobForum3._0.Data.JobForum3_0Context _context;

        public IndexModel(JobForum3._0.Data.JobForum3_0Context context)
        {
            _context = context;
        }

        public IList<TopicResponse> TopicResponse { get;set; } = default!;

        public async Task OnGetAsync()
        {
            TopicResponse = await _context.TopicResponse.ToListAsync();
        }
    }
}
