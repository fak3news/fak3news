using Fak3News.Domain.Interfaces;
using System;

namespace Fak3News.Domain.Models
{
    public class Article : DatabaseUnit, IModel
    {
        public string Content { get; set; }
    }
}
