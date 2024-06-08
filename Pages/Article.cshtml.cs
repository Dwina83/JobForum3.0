using JobForum3._0.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace JobForum3._0.Pages
{
    public class ArticleModel : PageModel
    {
        private readonly Data.JobForum3_0Context _context;

        public ArticleModel(Data.JobForum3_0Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Article Article { get; set; }
        public List<Article> ArticleList { get; set; }

        [BindProperty]
        public IFormFile UploadedFile { get; set; }

       

        public async Task OnGet()
        {
            ArticleList = await _context.Article.ToListAsync();
        }
    }
}
