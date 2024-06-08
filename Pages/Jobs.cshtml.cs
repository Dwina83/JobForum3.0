using JobForum3._0.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JobForum3._0.Pages
{
    public class JobsModel : PageModel
    {
        [BindProperty]
        public Models.JobAd JobAd { get; set; }
        public List<Models.JobAd> JobAds { get; set; }

        public Models.Hit SpecificJobAd { get; set; }

        public List<Models.Hit> SpecificJobAds  { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Municipality { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            JobAd = await DAL.JobAdManagerAPI.GetAllJobAds();

            return Page();
        }

       
    }
}
