using System;
using System.Threading.Tasks;
using Fak3News.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Fak3News.Web.Pages.API
{
    public class ArticleModel : PageModel
    {
        public ArticleModel(IArticleService service)
        {
            articleService = service;
        }

        private readonly IArticleService articleService;

        public async Task<JsonResult> OnGetAsync(Guid? id = null)
        {
            if (id == null)
                return new JsonResult(await articleService.GetAll());
            else
                return new JsonResult(await articleService.Get(id.Value));
        }
    }
}
