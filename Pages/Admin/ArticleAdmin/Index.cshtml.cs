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

namespace JobForum3._0.Pages.Admin.ArticleAdmin
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly JobForum3._0.Data.JobForum3_0Context _context;

        [BindProperty]
        public IFormFile UploadedFile { get; set; }
        public IndexModel(JobForum3._0.Data.JobForum3_0Context context)
        {
            _context = context;
        }

        public IList<Article> Article { get;set; } = default!;

        public Models.Article AnArticle { get; set; }

        public async Task OnGetAsync()
        {
            Article = await _context.Article.ToListAsync();
        }

        
    }
}
