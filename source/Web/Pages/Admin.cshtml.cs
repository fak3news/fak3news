using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Fak3News.Web.Pages
{
    public class AdminModel : PageModel
    {
        public IActionResult OnGet()
        {
            return RedirectToPage("Admin/Panel");
        }
    }
}
