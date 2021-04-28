using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fak3News.Domain.Interfaces.Services;
using Fak3News.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Fak3News.Web.Pages.Admin
{
    public class EditArticleModel : PageModel
    {
        public IArticleService ArticleService { get; set; }

        [BindProperty]
        public Article Article { get; set; }

        public EditArticleModel(IArticleService articleService)
        {
            ArticleService = articleService;
        }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            Article = await ArticleService.Get(id.GetValueOrDefault());

            if (Article == null)
                Article = new Article()
                { Id = Guid.NewGuid() };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                await ArticleService.Update(Article);
            }
            catch (Exception)
            {
                await ArticleService.Create(Article);
            }

            return RedirectToPage("Admin");
        }
    }
}
