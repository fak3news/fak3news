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
    public class EditArticleModel : PageModel
    {
        public IArticleService ArticleService { get; set; }

        public Article Article { get; set; }

        public EditArticleModel(IArticleService articleService)
        {
            ArticleService = articleService;
        }

        public async Task<IActionResult> OnGet(Guid id)
        {
            try
            {
                Article = await ArticleService.Get(id);
            }
            catch (Exception)
            {
            }

            return Page();
        }

        public void OnPostArticle(string id, string title, string description, string content)
        {
            if (id != null)
            {
                ArticleService.Update(new Article()
                {
                    Id = Guid.Parse(id),
                    Title = title,
                    Description = description,
                    Content = content
                });
            }
            else
            {
                ArticleService.Create(new Article()
                {
                    Title = title,
                    Description = description,
                    Content = content
                });
            }
        }
    }
}
