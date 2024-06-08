using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JobForum3._0.Data;
using JobForum3._0.Models;

namespace JobForum3._0.Pages.Admin.TopicResponseAdmin
{
    public class EditModel : PageModel
    {
        private readonly JobForum3._0.Data.JobForum3_0Context _context;

        public EditModel(JobForum3._0.Data.JobForum3_0Context context)
        {
            _context = context;
        }

        [BindProperty]
        public TopicResponse TopicResponse { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var topicresponse =  await _context.TopicResponse.FirstOrDefaultAsync(m => m.Id == id);
            if (topicresponse == null)
            {
                return NotFound();
            }
            TopicResponse = topicresponse;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(TopicResponse).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TopicResponseExists(TopicResponse.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TopicResponseExists(int id)
        {
            return _context.TopicResponse.Any(e => e.Id == id);
        }
    }
}
