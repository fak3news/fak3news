using Fak3News.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fak3News.Domain.Models.DbResources
{
    public class ArticleResource : DatabaseUnit, IModel
    {
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
