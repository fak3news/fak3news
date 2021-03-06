using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fak3News.Domain.Interfaces.Services;
using Fak3News.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Fak3News.Web.Pages
{
    public class AdminModel : PageModel
    {
        private readonly IArticleService articleService;
        public List<Article> Articles { get; set; } = new List<Article>();

        public AdminModel(IArticleService articleService)
        {
            this.articleService = articleService;
        }

        public async Task<IActionResult> OnGet()
        {
            if (User.Identity.IsAuthenticated)
            {
                Articles = (await articleService.GetAll()).OrderByDescending(a => a.CreatedAt.Ticks).ToList();
                return Page();
            }

            return RedirectToPage("Login");
        }
        public async Task<IActionResult> OnPostDeleteAsync(Guid id)
        {
            var article = await articleService.Get(id);

            if (article != null)
                await articleService.Delete(article);

            return new RedirectToPageResult("Admin");
        }

        public string IdToHtmlId(Guid id)
        {
            return "a" + id.ToString();
        }
    }
}
