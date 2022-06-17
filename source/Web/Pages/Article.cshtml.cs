using System;
using System.Threading.Tasks;
using Fak3News.Domain.Interfaces.Services;
using Fak3News.Domain.Models;
using Fak3News.Web.WebServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Fak3News.Web.Pages
{
    public class ArticleModel : PageModel
    {
        private readonly IArticleService articleService;

        public IMarkdownService MarkdownService { get; set; }
        public Article Article { get; set; }

        public ArticleModel(IArticleService articleService, IMarkdownService markdownService)
        {
            this.articleService = articleService;
            this.MarkdownService = markdownService;
        }

        public async Task<IActionResult> OnGet(Guid id)
        {
            Article = await articleService.Get(id);
            return Page();
        }
    }
}
