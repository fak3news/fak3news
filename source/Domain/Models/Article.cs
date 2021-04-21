using Domain.Interfaces;
using System;

namespace Domain.Models
{
    public class Article : DatabaseUnit, IModel
    {
        public byte[] Content { get; set; }
    }
}
