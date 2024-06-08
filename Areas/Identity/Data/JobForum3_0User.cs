using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace JobForum3._0.Areas.Identity.Data;

// Add profile data for application users by adding properties to the JobForum3_0User class
public class JobForum3_0User : IdentityUser
{
    [PersonalData]
    public string Forename { get; set; }

    [PersonalData]
    public string Surname { get; set; }
}

