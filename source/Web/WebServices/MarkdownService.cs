using Microsoft.AspNetCore.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Markdig;

namespace Fak3News.Web.WebServices
{
    public class MarkdownService : IMarkdownService
    {
        public HtmlString Parse(string markdown)
        {
            var pipeline = new MarkdownPipelineBuilder()
                .UseAdvancedExtensions()
                .Build();
            return new HtmlString(Markdown.ToHtml(markdown, pipeline));
        }
    }
}
