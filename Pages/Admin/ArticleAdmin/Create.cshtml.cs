using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using JobForum3._0.Data;
using JobForum3._0.Models;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.AspNetCore.Authorization;

namespace JobForum3._0.Pages.Admin.ArticleAdmin
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly JobForum3._0.Data.JobForum3_0Context _context;

        public CreateModel(JobForum3._0.Data.JobForum3_0Context context)
        {
            _context = context;
        }

        [BindProperty]
        public IFormFile UploadedFile { get; set; }

        [BindProperty]
        public Article Article { get; set; } 

        public IActionResult OnGet()
        {
            return Page();
        }



        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
           

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var file = UploadedFile;

            string fileName = string.Empty;

            if ( file is not null)
            {
                fileName =  file.FileName.Replace(":", "_").Replace(" ", "_");

                using (var fileStream = new FileStream(Path.Combine("./wwwroot/fileupload/", fileName), FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
            }

            Article.DatePosted = DateTime.Now;
            Article.FileUpload = fileName;

            _context.Article.Add(Article);
            await _context.SaveChangesAsync();


            return RedirectToPage("./Index");
        }
    }
}
