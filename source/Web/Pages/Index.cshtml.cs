using Domain.Interfaces.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger, IArticleService service)
        {
            _logger = logger;

            service.Create(new Article() { Content="Hello World" });
        }

        public void OnGet()
        {

        }
    }
}
