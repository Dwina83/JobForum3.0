using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using JobForum3._0.Data;
using JobForum3._0.Models;
using Microsoft.AspNetCore.Authorization;

namespace JobForum3._0.Pages.Admin.TopicAdmin
{
    [Authorize(Roles = "User")]
    public class CreateModel : PageModel
    {
        private readonly JobForum3._0.Data.JobForum3_0Context _context;

        public CreateModel(JobForum3._0.Data.JobForum3_0Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Topic Topic { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Topic.Add(Topic);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Topics");
        }
    }
}
