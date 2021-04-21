using Domain.Interfaces;
using System;

namespace Domain.Models
{
    public class Article : DataBaseUnit, IModel
    {
        public string Content { get; set; }
    }
}
