using Domain.Interfaces;
using System;

namespace Domain.Models
{
    public class Article : DatabaseUnit, IModel
    {
        public string Content { get; set; }
    }
}
