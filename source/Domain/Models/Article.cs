using Fak3News.Domain.Interfaces;
using System;

namespace Fak3News.Domain.Models
{
    public class Article : DatabaseUnit, IModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
