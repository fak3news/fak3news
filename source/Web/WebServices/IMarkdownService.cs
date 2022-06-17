using Microsoft.AspNetCore.Html;

namespace Fak3News.Web.WebServices
{
    public interface IMarkdownService
    {
        public HtmlString Parse(string markdown);
    }
}
