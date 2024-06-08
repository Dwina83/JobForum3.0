﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using JobForum3._0.Data;
using JobForum3._0.Models;

namespace JobForum3._0.Pages.Admin.ReportResponseAdmin
{
    public class DetailsModel : PageModel
    {
        private readonly JobForum3._0.Data.JobForum3_0Context _context;

        public DetailsModel(JobForum3._0.Data.JobForum3_0Context context)
        {
            _context = context;
        }

        public Report Report { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var report = await _context.Report.FirstOrDefaultAsync(m => m.Id == id);
            if (report == null)
            {
                return NotFound();
            }
            else
            {
                Report = report;
            }
            return Page();
        }
    }
}
