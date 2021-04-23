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
            Articles = (await articleService.GetAll()).ToList();
            return Page();
        }
    }
}
