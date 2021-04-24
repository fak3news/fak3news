using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fak3News.Domain.Interfaces.Services;
using Fak3News.Domain.Models;
using Fak3News.Web.WebServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Fak3News.Web.Pages
{
    public class IndexModel : PageModel
    {
        public IndexModel(IArticleService articelService, IMarkdownService markdownService)
        {
            articleService = articelService;
            MarkdownService = markdownService;
        }

        private readonly IArticleService articleService;

        public IMarkdownService MarkdownService { get; set; }

        public List<Article> Articles { get; set; } = new List<Article>();

        public async Task<IActionResult> OnGet()
        {
            Articles = (await articleService.GetAll()).ToList();
            return Page();
        }
    }
}
