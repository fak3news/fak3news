using Microsoft.AspNetCore.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fak3News.Web.WebServices
{
    public interface IMarkdownService
    {
        public HtmlString Parse(string markdown);
    }
}
